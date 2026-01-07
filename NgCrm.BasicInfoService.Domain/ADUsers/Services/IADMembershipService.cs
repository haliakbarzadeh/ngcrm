using NgCrm.BasicInfoService.Domain.ADUsers.Dtos;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Services
{
    public interface IADMembershipService
    {
        ADAuthenticaionResultDto Authenticate(string userName, string password);
    }
}
