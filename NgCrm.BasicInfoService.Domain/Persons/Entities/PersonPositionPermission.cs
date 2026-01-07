using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Persons.Entities
{
    [Auditable]
    public class PersonPositionPermission : Entity
    {
        public PersonPositionPermission(long personPositionId, long permissionId, bool isAllow)
        {
            PersonPositionId = personPositionId;
            PermissionId = permissionId;
            IsAllow = isAllow;
        }

        public bool Equals(PersonPositionPermission? obj)
        {
            if (obj is not PersonPositionPermission other)
                return false;

            return PersonPositionId == obj.PersonPositionId &&
                PermissionId == obj.PermissionId &&
                IsAllow == obj.IsAllow;
        }

        public long PersonPositionId { get; private set; }
        public long PermissionId { get; private set; }
        public bool IsAllow { get; private set; }
    }
}

