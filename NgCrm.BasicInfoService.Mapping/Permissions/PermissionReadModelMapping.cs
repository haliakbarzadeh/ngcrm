using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Permissions
{
    public class PermissionReadModelMapping : MapProfile<PermissionReadModel, PermissionDto>
    {
        public PermissionReadModelMapping()
        {
            //ForMember(x => x.Id, x => x.Id);
        }
    }
}
