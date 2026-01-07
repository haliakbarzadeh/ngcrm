using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Roles.Dtos;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Roles
{
    public class RoleReadModelMapping : MapProfile<RoleReadModel, RoleDto>
    {
        public RoleReadModelMapping()
        {
        }
    }


    public class RoleReadModelToRoleBriefDtoMapping : MapProfile<RoleReadModel, RoleBriefDto>
    {
        public RoleReadModelToRoleBriefDtoMapping()
        {
        }
    }
}
