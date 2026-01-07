using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.AccessGroups.Entities;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities
{
    [Auditable]
    public class PersonAccessGroup : AggregateRoot
    {
        public PersonAccessGroup(long personId, long accessGroupId)
        {
            PersonId = personId;
            AccessGroupId = accessGroupId;
        }

        public PersonAccessGroup(long personId, AccessGroup accessGroup)
        {
            PersonId = personId;
            AccessGroup = accessGroup;
        }

        public void Update(long personId, long accessGroupId)
        {
            PersonId = personId;
            AccessGroupId = accessGroupId;
        }

        public long PersonId { get; private set; }
        public long AccessGroupId { get; private set; }

        public virtual Person Person { get; private set; }
        public virtual AccessGroup AccessGroup { get; private set; }


    }
}