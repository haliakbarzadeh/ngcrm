
using MediatR;
using Microsoft.Extensions.Options;
using NgCrm.BasicInfoService.Application.ADUsers.Commands;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Proxy.AD.Contracts;

namespace NgCrm.BasicInfoService.Api.BackgroundTasks
{
    public class ADDataFetchTask : BackgroundService
    {
        private readonly ILogger<ADDataFetchTask> _logger;
        private readonly AppSetting _appSetting;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ADDataFetchTask(ILogger<ADDataFetchTask> logger, IOptions<AppSetting> options, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _appSetting = options.Value;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Here you could generate random AD users
                _logger.LogInformation("ADDataGatherTask GetAllUsersAsync at: {time}", DateTime.Now);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var adDataProxy = scope.ServiceProvider.GetRequiredService<IADDataProxy>();
                    var users = adDataProxy.GetAllUsers();
                    var sender = scope.ServiceProvider.GetRequiredService<ISender>();

                    foreach (var user in users)
                    {
                        var createOrUpdateADUserCommand = new CreateOrUpdateADUserCommand
                        {
                            UserName = user.UserName,
                            UserId = user.UserId,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            DisplayName = user.DisplayName,
                            Email = user.Email,
                            IsActive = user.IsActive,
                            Position = user.Position,
                            Department = user.Department,
                            Groups = user.Groups,
                            IsCsUser = user.IsCsUser,
                            TelephoneNumber = user.TelephoneNumber,
                            UserPrincipalName = user.UserPrincipalName
                        };

                        if (!await sender.Send(createOrUpdateADUserCommand, stoppingToken))
                            _logger.LogError("ADDataGatherTask error for User:{}", user.UserName);
                    }
                }

                await Task.Delay(TimeSpan.FromHours(_appSetting.TaskConfig.ADDataFetchIntervalHour), stoppingToken);
            }

            _logger.LogInformation("ADDataGatherTask ended.");
        }
    }
}
