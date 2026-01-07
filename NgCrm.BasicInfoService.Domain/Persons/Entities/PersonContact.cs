using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Persons.Entities
{
    [Auditable]
    public class PersonContact : Entity
    {
        public PersonContact(
            long personId,
            PersonContactTypes contactTypeId,
            string contact,
            bool isActive,
            int priorityOrder)
        {
            PersonId = personId;
            ContactTypeId = contactTypeId;
            Contact = contact;
            IsActive = isActive;
            PriorityOrder = priorityOrder;
        }

        public bool Equals(PersonContact? obj)
        {
            if (obj is not PersonContact other)
                return false;

            return PersonId == obj.PersonId &&
                ContactTypeId == obj.ContactTypeId &&
                Contact == obj.Contact &&
                IsActive == obj.IsActive &&
                PriorityOrder == obj.PriorityOrder;
        }

        public long PersonId { get; private set; }
        public PersonContactTypes ContactTypeId { get; private set; }
        public string Contact { get; private set; }
        public bool IsActive { get; private set; }
        public int PriorityOrder { get; private set; }
    }
}

