using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.ADUsers.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.ADUser
{
    public class ADUserMapping : MapProfile<ADUserReadModel, SelectItemDto>
    {
        public ADUserMapping()
        {
            ForMember(x => x.Title, x => x.FirstName + " " + x.LastName);
            ForMember(x => x.Tag, x => x.UserName + " | FirstName : " + (x.FirstName ?? "***") + " | LastName : " + (x.LastName ?? "***"));
        }
    }
}
