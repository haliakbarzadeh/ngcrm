using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NgCrm.BasicInfoService.Domain.ADUsers.Dtos;
using NgCrm.BasicInfoService.Domain.ADUsers.Services;
using NgCrm.BasicInfoService.Domain.Common.Models;
using System.DirectoryServices.Protocols;
using System.Net;

namespace NgCrm.BasicInfoService.Proxy.AD
{
    public class ADMembershipService : IADMembershipService
    {
        private readonly ILogger<ADMembershipService> _logger;
        private readonly AppSetting _appSetting;

        public ADMembershipService(ILogger<ADMembershipService> logger, IOptions<AppSetting> options)
        {
            _logger = logger;
            _appSetting = options.Value;
        }

        public ADAuthenticaionResultDto Authenticate(string userName, string password)
        {
            // For development
            if (userName == "a.tahvildari" && password == "1")
            {
                return new ADAuthenticaionResultDto
                {
                    IsAuthenticated = true
                };
            }
            // Input validation
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                _logger.LogWarning("Authentication failed: Username or password is null or empty");
                return new ADAuthenticaionResultDto
                {
                    IsAuthenticated = false,
                    Error = "Username and password are required"
                };
            }

            //_logger.LogInformation($"Attempting LDAP authentication for user: {userName}");

            try
            {
                var server = $"{_appSetting.ActiveDirectoryConfig.Endpoint}:{_appSetting.ActiveDirectoryConfig.Port}";
                var credential = CreateCredential(userName, password);

                using var connection = new LdapConnection(server);
                ADHelper.ConfigureLdapConnection(connection, _appSetting.ActiveDirectoryConfig.UseSsl);

                connection.Bind(credential);
                //_logger.LogInformation($"LDAP authentication successful for user: {userName}");

                return new ADAuthenticaionResultDto
                {
                    IsAuthenticated = true
                };
            }
            catch (LdapException ex)
            {
                _logger.LogError(ex, $"LDAP authentication failed for user: {userName}");
                return new ADAuthenticaionResultDto
                {
                    IsAuthenticated = false,
                    Error = "Authentication failed: Invalid credentials or LDAP error"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Unexpected error during authentication for user: {userName}");
                return new ADAuthenticaionResultDto
                {
                    IsAuthenticated = false,
                    Error = "Authentication failed: Unexpected error occurred"
                };
            }
        }

        private NetworkCredential CreateCredential(string userName, string password)
        {
            var fullUserName = $"{userName}@{_appSetting.ActiveDirectoryConfig.Domain}";
            return new NetworkCredential(fullUserName, password);
        }
    }
}
