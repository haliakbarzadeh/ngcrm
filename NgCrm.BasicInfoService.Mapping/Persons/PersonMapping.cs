using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Persons
{
    public class PersonMapping : MapProfile<Person, PersonDto>
    {
        public PersonMapping()
        {
            //ForMember(x => x.Id, x => x.Id);
        }
    }


    public class PersonPositionReadModelToSelectItemDtoMapping : MapProfile<PersonPositionReadModel, SelectItemDto>
    {
        public PersonPositionReadModelToSelectItemDtoMapping()
        {
            ForMember(x => x.Id, x => x.PositionId);
            ForMember(x => x.Title, x => x.Position.Title);
            ForMember(x => x.Tag, x => x.Position.Name);
        }
    }

    public class PersonReadModelToPersonBriefDtoMapping : MapProfile<PersonReadModel, PersonBriefDto>
    {
        public PersonReadModelToPersonBriefDtoMapping()
        {
            ForMember(x => x.FullName, x => x.IsLegal ? x.CompanyName : (x.FirstName + " " + x.LastName));
        }
    }

    public class PersonReadModelToSelectItemDtoMapping : MapProfile<PersonReadModel, SelectItemDto>
    {
        public PersonReadModelToSelectItemDtoMapping()
        {
            ForMember(x => x.Title, e => e.FirstName + " " + e.LastName);
            ForMember(x => x.Tag, e => e.FirstName + " " + e.LastName + " | کدملی : " + e.NationalCode + " | کد پرسنلی : " + e.PersonalCode);
        }
    }

    public class PersonReadModelToPersonSummaryDtoMapping : MapProfile<PersonReadModel, PersonSummaryDto
>
    {
        public PersonReadModelToPersonSummaryDtoMapping()
        {
            ForMember(x => x.FullName, e => e.FirstName + " " + e.LastName);
            ForMember(x => x.Title, e => e.FirstName + " " + e.LastName + " | کدملی : " + e.NationalCode + " | کد پرسنلی : " + e.PersonalCode);
        }
    }
}
