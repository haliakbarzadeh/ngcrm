using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.Entities
{
    [Auditable]
    public class Person : AggregateRoot
    {
        public Person(string firstName,
        string lastName,
        string fatherName,
        string companyName,
        bool isLegal,
        string nationalCode,
        GenderTypes? genderTypeId,
        MarriageTypes? marriageTypeId,
        DateTime? birthDate,
        string birthPlace,
        string personalCode,
        GenderTypes? degreeTypeId,
        string major,
        bool? isActive,
        Guid? imageId,
        string contactName,
        int? registrationNumber,
        ContractTypes? contractTypeId,
        DateTime? startDate)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            CompanyName = companyName;
            IsLegal = isLegal;
            NationalCode = nationalCode;
            GenderTypeId = genderTypeId;
            MarriageTypeId = marriageTypeId;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            PersonalCode = personalCode;
            DegreeTypeId = degreeTypeId;
            Major = major;
            IsActive = isActive;
            ImageId = imageId;
            ContactName = contactName;
            RegistrationNumber = registrationNumber;
            ContractTypeId = contractTypeId;
            StartDate = startDate;
        }


        public void Update(
            string firstName,
            string lastName,
            string fatherName,
            string companyName,
            bool isLegal,
            string nationalCode,
            GenderTypes? genderTypeId,
            MarriageTypes? marriageTypeId,
            DateTime? birthDate,
            string birthPlace,
            string personalCode,
            GenderTypes? degreeTypeId,
            string major,
            bool? isActive,
            Guid? imageId,
            string contactName,
            int? registrationNumber,
            ContractTypes? contractTypeId,
            DateTime? startDate)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            CompanyName = companyName;
            IsLegal = isLegal;
            NationalCode = nationalCode;
            GenderTypeId = genderTypeId;
            MarriageTypeId = marriageTypeId;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            PersonalCode = personalCode;
            DegreeTypeId = degreeTypeId;
            Major = major;
            IsActive = isActive;
            ImageId = imageId;
            ContactName = contactName;
            RegistrationNumber = registrationNumber;
            ContractTypeId = contractTypeId;
            StartDate = startDate;
        }


        public void SetPersonAddresses(IEnumerable<PersonAddress> newPersonAddresses)
        {
            var listAdd = newPersonAddresses
                .Where(n => !PersonAddresses.Any(e => e.Equals(n)))
                .ToList();

            var listDelete = PersonAddresses
                .Where(d => !newPersonAddresses.Any(n => n.Equals(d)))
                .ToList();


            foreach (var item in listDelete)
            {
                item.Archive();
            }

            foreach (var item in listAdd)
            {
                PersonAddresses.Add(item);
            }
        }

        public void SetPersonContacts(IEnumerable<PersonContact> newPersonContacts)
        {
            var listAdd = newPersonContacts
               .Where(n => !PersonContacts.Any(e => e.Equals(n)))
               .ToList();

            var listDelete = PersonContacts
                .Where(d => !newPersonContacts.Any(n => n.Equals(d)))
                .ToList();


            foreach (var item in listDelete)
            {
                item.Archive();
            }

            foreach (var item in listAdd)
            {
                PersonContacts.Add(item);
            }
        }

        public void SetPersonPosition(IEnumerable<PersonPosition> newPersonPositions)
        {
            var listAdd = newPersonPositions
              .Where(n => !PersonPositions.Any(e => e.Equals(n)))
              .ToList();

            var listDelete = PersonPositions
                .Where(d => !newPersonPositions.Any(n => n.Equals(d)))
                .ToList();


            foreach (var item in listDelete)
            {
                item.Archive();
            }

            foreach (var item in listAdd)
            {
                PersonPositions.Add(item);
            }
        }

        public void ToggleIsActive()
        {
            IsActive = !IsActive;
            ModifiedAt = DateTime.Now;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FatherName { get; private set; }
        public string CompanyName { get; private set; }
        public bool IsLegal { get; private set; }
        public string NationalCode { get; private set; }
        public GenderTypes? GenderTypeId { get; private set; }
        public MarriageTypes? MarriageTypeId { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string BirthPlace { get; private set; }
        public string PersonalCode { get; private set; }
        public GenderTypes? DegreeTypeId { get; private set; }
        public string Major { get; private set; }
        public bool? IsActive { get; private set; }
        public Guid? ImageId { get; private set; }
        public int? RegistrationNumber { get; private set; }
        public string ContactName { get; private set; }
        public ContractTypes? ContractTypeId { get; private set; }
        public DateTime? StartDate { get; private set; }

        public virtual ICollection<PersonContact> PersonContacts { get; private set; } = new List<PersonContact>();
        public virtual ICollection<PersonAddress> PersonAddresses { get; private set; } = new List<PersonAddress>();
        public virtual ICollection<PersonPosition> PersonPositions { get; private set; } = new List<PersonPosition>();
    }
}