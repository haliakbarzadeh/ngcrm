using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Roles.Dtos;
using NgCrm.BasicInfoService.Domain.Roles.Entities;

namespace NgCrm.BasicInfoService.Mapping.Roles
{
    public class RoleMapping : MapProfile<Role, RoleDto>
    {
        public RoleMapping()
        {
            ForMember(x => x.Id, x => x.Id);
        }
    }
}
