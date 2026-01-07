using MediatR;
using Microsoft.Extensions.Options;
using NgCrm.BasicInfoService.Application.Locations.Commands;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Domain.Locations.Enums;
using NgCrm.BasicInfoService.Proxy.Map.Contracts;

namespace NgCrm.BasicInfoService.Api.BackgroundTasks
{
    public class MapDataProxyFetchTask : BackgroundService
    {

        private readonly ILogger<MapDataProxyFetchTask> _logger;
        private readonly AppSetting _appSetting;
        private readonly IServiceScopeFactory _serviceScopeFactory;


        public MapDataProxyFetchTask(ILogger<MapDataProxyFetchTask> logger, IOptions<AppSetting> options, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _appSetting = options.Value;

        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("MapProxyFetchTask Service started.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("MapProxyFetchTask GetAllProvinceAsync at: {time}", DateTime.Now);

                    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var mapDataProxy = scope.ServiceProvider.GetRequiredService<IMapDataProxy>();
                        var provinces = await mapDataProxy.GetAllProvincesAsync();
                        var sender = scope.ServiceProvider.GetRequiredService<ISender>();

                        foreach (var province in provinces)
                        {
                            try
                            {
                                var createProvinceLocationCommand = new CreateOrUpdateLocationCommand
                                {
                                    Geometry = province.Geometry,
                                    LocationTypeId = LocationTypes.Province,
                                    Title = province.Name,
                                    OriginalId = province.Id,
                                };

                                var provinceId = await sender.Send(createProvinceLocationCommand, stoppingToken);
                                if (provinceId <= 0)
                                    _logger.LogError("MapProxyFetchTask error for province: {ProvinceName}", province.Name);

                                var cities = await mapDataProxy.GetCitiesByProvinceIdAsync(province.Id);
                                foreach (var city in cities)
                                {
                                    try
                                    {
                                        var createCityLocationCommand = new CreateOrUpdateLocationCommand
                                        {
                                            Geometry = city.Geometry,
                                            LocationTypeId = LocationTypes.City,
                                            Title = city.Name,
                                            OriginalId = city.Id,
                                            ParentId = provinceId
                                        };

                                        var cityId = await sender.Send(createCityLocationCommand, stoppingToken);
                                        if (cityId <= 0)
                                            _logger.LogError("MapProxyFetchTask error for city: {CityName}", city.Name);
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.LogError(ex, "Error processing city {CityName} in province {ProvinceName}", city.Name, province.Name);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                _logger.LogError(ex, "Error processing province {ProvinceName}", province.Name);
                            }
                        }
                    }
                }
                catch (HttpRequestException httpEx)
                {
                    _logger.LogError(httpEx, "HTTP error occurred while fetching map data. Will retry after interval.");
                }
                catch (TaskCanceledException tcEx) when (tcEx.InnerException is TimeoutException)
                {
                    _logger.LogError(tcEx, "Timeout occurred while fetching map data. Will retry after interval.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error occurred in MapProxyFetchTask. Will retry after interval.");
                }

                try
                {
                    await Task.Delay(TimeSpan.FromDays(_appSetting.TaskConfig.MapDataFetchIntervalDay), stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    _logger.LogInformation("MapProxyFetchTask cancellation requested.");
                    break;
                }
            }

            _logger.LogInformation("MapProxyFetchTask ended.");
        }
    }
}
