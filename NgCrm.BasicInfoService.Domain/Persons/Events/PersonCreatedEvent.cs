using Goldiran.Framework.Domain.Events;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.Events
{
    public class PersonCreatedEvent : CreatedDomainEvent
    {
        public PersonCreatedEvent(Guid businessId,
                                string firstName,
                                string lastName,
                                string fatherName,
                                string title,
                                bool isLegal,
                                string nationalCode,
                                GenderTypes? genderTypeId,
                                MarriageTypes? marriageTypeId,
                                DateTime? birthDate,
                                string birthPlace,
                                string personalCode,
                                GenderTypes? degreeTypeId,
                                string major,
                                bool isActive,
                                ICollection<PersonContact> personContacts,
                                ICollection<PersonAddress> personAddresses,
                                DateTime createdAt) : base(businessId, createdAt)
        {
            FirstName = firstName;
            LastName = lastName;
            FatherName = fatherName;
            Title = title;
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
            PersonContacts = personContacts ?? new List<PersonContact>();
            PersonAddresses = personAddresses ?? new List<PersonAddress>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FatherName { get; private set; }
        public string Title { get; private set; }
        public bool IsLegal { get; private set; }
        public string NationalCode { get; private set; }
        public GenderTypes? GenderTypeId { get; private set; }
        public MarriageTypes? MarriageTypeId { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string BirthPlace { get; private set; }
        public string PersonalCode { get; private set; }
        public GenderTypes? DegreeTypeId { get; private set; }
        public string Major { get; private set; }
        public bool IsActive { get; private set; }


        public virtual ICollection<PersonContact> PersonContacts { get; private set; } = new List<PersonContact>();
        public virtual ICollection<PersonAddress> PersonAddresses { get; private set; } = new List<PersonAddress>();

    }
}
