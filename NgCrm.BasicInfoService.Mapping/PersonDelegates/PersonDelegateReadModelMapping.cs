using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos;
using NgCrm.BasicInfoService.Domain.PersonDelegates.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.PersonDelegates
{
    public class PersonDelegateReadModelMapping : MapProfile<PersonDelegateReadModel, PersonDelegateDto>
    {
        public PersonDelegateReadModelMapping()
        {
            ForMember(x => x.ReasonTypeTitle, x => x.ReasonTypeId.GetEnumDescription());
            ForMember(x => x.StatusTypeTitle, x => x.StatusTypeId.GetEnumDescription());

            ForMember(x => x.AssignerPersonFullName, x => $"{x.AssignerPerson.FirstName} {x.AssignerPerson.LastName}");
            ForMember(x => x.AssignerPositionTitle, x => x.AssignerPosition.Title);
            ForMember(x => x.DelegatePersonFullName, x => $"{x.DelegatePerson.FirstName} {x.DelegatePerson.LastName}");
        }
    }

    public class PersonDelegateReadModelToPersonDelegateBriefDtoMapping : MapProfile<PersonDelegateReadModel, PersonDelegateBriefDto>
    {
        public PersonDelegateReadModelToPersonDelegateBriefDtoMapping()
        {
            ForMember(x => x.ReasonTypeTitle, x => x.ReasonTypeId.GetEnumDescription());
            ForMember(x => x.StatusTypeTitle, x => x.StatusTypeId.GetEnumDescription());

            ForMember(x => x.AssignerPersonFullName, x => $"{x.AssignerPerson.FirstName} {x.AssignerPerson.LastName}");
            ForMember(x => x.AssignerPositionTitle, x => x.AssignerPosition.Title);
            ForMember(x => x.DelegatePersonFullName, x => $"{x.DelegatePerson.FirstName} {x.DelegatePerson.LastName}");
            ForMember(x => x.CreatePersonFullName, x => $"{x.CreatePerson.FirstName} {x.CreatePerson.LastName}");
        }
    }
}