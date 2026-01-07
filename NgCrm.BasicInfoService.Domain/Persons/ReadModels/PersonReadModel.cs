using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.ReadModels
{
    public class PersonReadModel : ReadModel
    {
        public PersonReadModel()
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string CompanyName { get; set; }
        public bool IsLegal { get; set; }
        public string NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public MarriageTypes? MarriageTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string PersonalCode { get; set; }
        public DegreeTypes? DegreeTypeId { get; set; }
        public string Major { get; set; }
        public bool? IsActive { get; set; }
        public Guid? ImageId { get; set; }
        public int? RegistrationNumber { get; set; }
        public string ContactName { get; set; }
        public ContractTypes? ContractTypeId { get; set; }
        public DateTime? StartDate { get; set; }


        public virtual ICollection<PersonContactReadModel> PersonContacts { get; set; } = new List<PersonContactReadModel>();
        public virtual ICollection<PersonAddressReadModel> PersonAddresses { get; set; } = new List<PersonAddressReadModel>();
        public virtual ICollection<PersonPositionReadModel> PersonPositions { get; set; } = new List<PersonPositionReadModel>();

    }
}