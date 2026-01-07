using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonDto : Dto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string CompanyName { get; set; }
        public bool IsLegal { get; set; }
        public string NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public string GenderTypeTitle { get; set; }
        public MarriageTypes? MarriageTypeId { get; set; }
        public string MarriageTypeTitle { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string PersonalCode { get; set; }
        public GenderTypes? DegreeTypeId { get; set; }
        public string DegreeTypeTitle { get; set; }
        public string Major { get; set; }
        public bool? IsActive { get; set; }
        public Guid? ImageId { get; set; }
        public int? RegistrationNumber { get; set; }
        public string ContactName { get; set; }
        public ContractTypes? ContractTypeId { get; set; }
        public DateTime? StartDate { get; set; }

        public ICollection<PersonContactDto> PersonContacts { get; set; } = new List<PersonContactDto>();
        public ICollection<PersonAddressDto> PersonAddresses { get; set; } = new List<PersonAddressDto>();
        public ICollection<PersonPositionDto> PersonPositions { get; set; } = new List<PersonPositionDto>();
    }
}
