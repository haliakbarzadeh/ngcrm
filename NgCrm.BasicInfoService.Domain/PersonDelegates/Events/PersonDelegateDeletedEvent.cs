using Goldiran.Framework.Domain.Events;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Events
{
    public class PersonDelegateDeletedEvent : DeletedDomainEvent
    {
        public PersonDelegateDeletedEvent(long id, Guid businessId, long AssignerPersonId, long delegatePersonId)
            : base(id, businessId)
        {
            AssignerPersonId = AssignerPersonId;
            DelegatePersonId = delegatePersonId;
        }

        public long AssignerPersonId { get; private set; }
        public long DelegatePersonId { get; private set; }
    }
}