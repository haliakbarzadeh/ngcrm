using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Persons
{
    public class PersonReadModelMapping : MapProfile<PersonReadModel, PersonDto>
    {
        public PersonReadModelMapping()
        {
            ForMember(x => x.DegreeTypeTitle, x => x.DegreeTypeId != null ? x.DegreeTypeId.GetEnumDescription() : "");
            ForMember(x => x.GenderTypeTitle, x => x.GenderTypeId != null ?  x.GenderTypeId.GetEnumDescription() : "");
            ForMember(x => x.MarriageTypeTitle, x => x.MarriageTypeId != null ? x.MarriageTypeId.GetEnumDescription() : "");
            ForMember(x => x.PersonAddresses, x => x.PersonAddresses);
            ForMember(x => x.PersonContacts, x => x.PersonContacts);
        }
    }
}
