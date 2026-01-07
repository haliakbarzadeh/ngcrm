using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.PersonAccessGroups
{
    public class PersonAccessGroupReadModelMapping : MapProfile<PersonAccessGroupReadModel, PersonAccessGroupDto>
    {
        public PersonAccessGroupReadModelMapping()
        {
        }
    }

    public class PersonAccessGroupReadModelToPersonAccessGroupBriefDtoMapping : MapProfile<PersonAccessGroupReadModel, PersonAccessGroupBriefDto>
    {
        public PersonAccessGroupReadModelToPersonAccessGroupBriefDtoMapping()
        {
            ForMember(x => x.AccessGroupTitle, x => x.AccessGroup.Title);
            ForMember(x => x.PersonName, x => x.Person.FirstName + " " + x.Person.LastName);
        }
    }
}