using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;

namespace NgCrm.BasicInfoService.Mapping.Permissions
{
    public class PermissionMapping : MapProfile<Permission, PermissionDto>
    {
        public PermissionMapping()
        {
            //ForMember(x => x.Id, x => x.Id);
        }
    }
}
