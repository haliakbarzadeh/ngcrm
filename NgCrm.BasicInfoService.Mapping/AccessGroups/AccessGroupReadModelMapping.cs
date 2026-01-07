using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.AccessGroups
{
    public class AccessGroupReadModelMapping : MapProfile<AccessGroupReadModel, AccessGroupDto>
    {
        public AccessGroupReadModelMapping()
        {
            //ForMember(x => x.I x => x.Id);
        }
    }
}