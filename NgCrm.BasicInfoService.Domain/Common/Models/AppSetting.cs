using Goldiran.Framework.Domain.Models;

namespace NgCrm.BasicInfoService.Domain.Common.Models
{
    public class AppSetting : AppSettingBase
    {
        public AppSetting() { }

        public TaskConfig TaskConfig { get; set; }
        public JwtConfig JwtConfig { get; set; }

        public MapConfig MapConfig { get; set; }
        public ActiveDirectoryConfig ActiveDirectoryConfig { get; set; }
    }

    public class MapConfig
    {
        public string ApiKey { get; set; }

        public string GetAllProvinces { get; set; }
        public string GetCitiesByProvinceId { get; set; }
        public string ReverseGeocode { get; set; }

        public string Search { get; set; }
    }

    public class TaskConfig
    {
        public int ADDataFetchIntervalHour { get; set; }

        public int MapDataFetchIntervalDay { get; set; }
    }

    public class JwtConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int ExpiresHours { get; set; }
        public IEnumerable<JwtClient> Clients { get; set; }

        public class JwtClient
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }
        }
    }

    public class ActiveDirectoryConfig
    {
        public string Endpoint { get; set; }
        public string Domain { get; set; }
        public bool UseSsl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
