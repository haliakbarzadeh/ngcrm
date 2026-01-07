using System.DirectoryServices.Protocols;

namespace NgCrm.BasicInfoService.Proxy.AD
{
    public static class ADHelper
    {
        public static void ConfigureLdapConnection(LdapConnection connection, bool useSsl)
        {
            connection.SessionOptions.ReferralChasing = ReferralChasingOptions.None;
            connection.SessionOptions.SecureSocketLayer = useSsl; // Make this configurable
            connection.AuthType = AuthType.Basic;
            connection.SessionOptions.ProtocolVersion = 3;
        }
    }
}
