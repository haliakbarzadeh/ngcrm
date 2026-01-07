using System.Security.Claims;

namespace NgCrm.BasicInfoService.Domain.Users.Services
{
    public interface ITokenService
    {
        string CreateToken(string userName, IEnumerable<Claim> extra = null);
    }
}
