using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.Dtos;

namespace NgCrm.BasicInfoService.Mapping.PersonPositionPermissions
{
    public class PersonPositionPermissionMapping : MapProfile<PersonPositionPermission, PersonPositionPermissionDto>
    {
        public PersonPositionPermissionMapping()
        {
            //ForMember(x => x.Id, x => x.Id);
        }
    }
}
