using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Proxy.AD.Contracts;
using NgCrm.BasicInfoService.Proxy.AD.Models;
using System.DirectoryServices.Protocols;
using System.Net;

namespace NgCrm.BasicInfoService.Proxy.AD
{
    public class ADDataProxy : IADDataProxy
    {
        private readonly AppSetting _appSetting;
        private readonly ILogger<ADDataProxy> _logger;

        public ADDataProxy(IOptions<AppSetting> options, ILogger<ADDataProxy> logger)
        {
            _appSetting = options.Value;
            _logger = logger;
        }

        public IEnumerable<ADUserModel> GetAllUsers()
        {
            var allADUsers = new List<ADUserModel>();

            try
            {
                _logger.LogInformation("Starting AD user retrieval...");
                var server = $"{_appSetting.ActiveDirectoryConfig.Endpoint}:{_appSetting.ActiveDirectoryConfig.Port}";

                using var connection = new LdapConnection(server);

                ADHelper.ConfigureLdapConnection(connection, _appSetting.ActiveDirectoryConfig.UseSsl);

                var credential = CreateCredential();

                try
                {
                    _logger.LogInformation("Attempting LDAP authentication...");
                    connection.Bind(credential);
                    _logger.LogInformation("LDAP connection established successfully");

                    var distinguishedName = BuildDistinguishedName();
                    var searchRequest = CreateSearchRequest(distinguishedName);

                    allADUsers.AddRange(ExecutePagedSearch(connection, searchRequest));

                    _logger.LogInformation("Retrieved {UserCount} users from Active Directory", allADUsers.Count);
                }
                catch (LdapException ex)
                {
                    _logger.LogError(ex, "LDAP authentication failed");
                    throw;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during Active Directory operation");
                    throw;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to retrieve users from Active Directory");

            }

            return allADUsers;
        }

        private NetworkCredential CreateCredential()
        {
            var userName = $"{_appSetting.ActiveDirectoryConfig.UserName}@{_appSetting.ActiveDirectoryConfig.Domain}";
            return new NetworkCredential(userName, _appSetting.ActiveDirectoryConfig.Password);
        }

        private string BuildDistinguishedName()
        {
            var domainParts = _appSetting.ActiveDirectoryConfig.Domain.Split('.');
            if (domainParts.Length < 2)
                throw new InvalidOperationException("Invalid domain format. Expected format: 'domain.com'");

            return $"DC={domainParts[0]},DC={domainParts[1]}";
        }

        private static SearchRequest CreateSearchRequest(string distinguishedName)
        {
            const string userFilter = "(&(objectCategory=person)(objectClass=user))"; // More specific filter

            var attributes = new[]
            {
                "objectGUID", "sAMAccountName", "userPrincipalName", "displayName",
                "mail", "givenName", "sn", "title", "department", "telephoneNumber",
                "userAccountControl", "memberOf", "distinguishedName"
            };

            var request = new SearchRequest(distinguishedName, userFilter, SearchScope.Subtree, attributes);

            const int pageSize = 1000; // Configurable page size
            var pageRequestControl = new PageResultRequestControl(pageSize);
            request.Controls.Add(pageRequestControl);

            return request;
        }

        private List<ADUserModel> ExecutePagedSearch(LdapConnection connection, SearchRequest request)
        {
            var users = new List<ADUserModel>();
            var pageRequestControl = (PageResultRequestControl)request.Controls[0];

            while (true)
            {
                var response = (SearchResponse)connection.SendRequest(request);

                foreach (SearchResultEntry entry in response.Entries)
                {
                    var adUser = MapSearchEntryToUser(entry);
                    if (!string.IsNullOrEmpty(adUser.UserName))
                        users.Add(adUser);
                }

                // Check for next page
                var pageResponse = response.Controls
                    .OfType<PageResultResponseControl>()
                    .FirstOrDefault();

                if (pageResponse?.Cookie == null || pageResponse.Cookie.Length == 0)
                    break;

                pageRequestControl.Cookie = pageResponse.Cookie;
            }

            return users;
        }

        private static ADUserModel MapSearchEntryToUser(SearchResultEntry entry)
        {
            var user = new ADUserModel();

            user.UserName = GetAttributeValue(entry, "sAMAccountName");
            user.DisplayName = GetAttributeValue(entry, "displayName");
            user.FirstName = GetAttributeValue(entry, "givenName");
            user.LastName = GetAttributeValue(entry, "sn");
            user.UserPrincipalName = GetAttributeValue(entry, "userPrincipalName");
            user.Position = GetAttributeValue(entry, "title");
            user.TelephoneNumber = GetAttributeValue(entry, "telephoneNumber");
            user.Department = GetAttributeValue(entry, "department");
            user.Email = GetAttributeValue(entry, "mail");

            // Handle GUID
            if (entry.Attributes["objectGUID"]?.Count > 0)
                user.UserId = new Guid((byte[])entry.Attributes["objectGUID"][0]);

            // Handle Groups (should ideally use memberOf instead of distinguishedName)
            user.Groups = GetAttributeValue(entry, "distinguishedName");
            user.IsCsUser = user.Groups?.Contains("OU=CS", StringComparison.OrdinalIgnoreCase) ?? false;

            // Handle user account status
            if (entry.Attributes["userAccountControl"]?.Count > 0)
            {
                const int accountDisabledFlag = 0x0002;
                var userAccountControl = Convert.ToInt32(entry.Attributes["userAccountControl"][0].ToString());
                user.IsActive = (userAccountControl & accountDisabledFlag) == 0;
            }

            return user;
        }

        private static string GetAttributeValue(SearchResultEntry entry, string attributeName)
        {
            return entry.Attributes[attributeName]?.Count > 0
                ? entry.Attributes[attributeName][0].ToString()
                : null;
        }
    }
}
