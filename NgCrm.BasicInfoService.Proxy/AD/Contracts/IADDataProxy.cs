using NgCrm.BasicInfoService.Proxy.AD.Models;

namespace NgCrm.BasicInfoService.Proxy.AD.Contracts
{
    public interface IADDataProxy
    {
        IEnumerable<ADUserModel> GetAllUsers();
    }
}
