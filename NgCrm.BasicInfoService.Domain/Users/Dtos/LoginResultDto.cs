using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Domain.Users.Dtos
{
    public class LoginResultDto : Dto
    {
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Token { get; set; }
        public LoginTypes LoginType { get; set; }
        public bool HasSinglePosition { get; set; }
    }
}
