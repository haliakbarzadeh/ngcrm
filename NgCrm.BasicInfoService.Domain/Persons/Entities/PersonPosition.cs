using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Persons.Entities
{
    [Auditable]
    public class PersonPosition : Entity
    {
        public PersonPosition(long personId, long positionId, DateTime startDate, DateTime? endDate, string internalNumber, bool isActive)
        {
            PersonId = personId;
            PositionId = positionId;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
            InternalNumber = internalNumber;
        }

        public void ToggleIsActive()
        {
            IsActive = !IsActive;
            ModifiedAt = DateTime.Now;
        }

        public bool Equals(PersonPosition? obj)
        {
            if (obj is not PersonPosition other)
                return false;

            return PersonId == obj.PersonId &&
                PositionId == obj.PositionId &&
                StartDate == obj.StartDate &&
                EndDate == obj.EndDate &&
                IsActive == obj.IsActive &&
                InternalNumber == obj.InternalNumber;
        }

        public void SetPersonPositionPermission(IEnumerable<PersonPositionPermission> personPositionPermissions)
        {
            var listAdd = personPositionPermissions
              .Where(n => !PersonPositionPermissions.Any(e => e.Equals(n)))
              .ToList();

            var listDelete = PersonPositionPermissions
                .Where(d => !personPositionPermissions.Any(n => n.Equals(d)))
                .ToList();


            foreach (var item in listDelete)
            {
                item.Archive();
            }

            foreach (var item in listAdd)
            {
                PersonPositionPermissions.Add(item);
            }
        }

        public long PersonId { get; private set; }
        public long PositionId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public bool IsActive { get; private set; }
        public string InternalNumber { get; private set; }


        public virtual ICollection<PersonPositionPermission> PersonPositionPermissions { get; private set; } = new List<PersonPositionPermission>();
    }
}

