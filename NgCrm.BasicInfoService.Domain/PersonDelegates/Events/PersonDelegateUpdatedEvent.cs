using Goldiran.Framework.Domain.Events;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Events
{
    public class PersonDelegateUpdatedEvent : UpdatedDomainEvent
    {
        public PersonDelegateUpdatedEvent(long id, Guid businessId, DateTime modifiedAt, long assignerPersonId, long assignerPositionId, long delegatePersonId, DateTime fromDate, DateTime? toDate, DelegateReasonTypes reasonTypeId, DelegateStatusTypes statusTypeId, string description)
            : base(id, businessId, modifiedAt)
        {
            AssignerPersonId = assignerPersonId;
            AssignerPositionId = assignerPositionId;
            DelegatePersonId = delegatePersonId;
            FromDate = fromDate;
            ToDate = toDate;
            ReasonTypeId = reasonTypeId;
            StatusTypeId = statusTypeId;
            Description = description;
        }

        public long AssignerPersonId { get; private set; }
        public long AssignerPositionId { get; private set; }
        public long DelegatePersonId { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public DelegateReasonTypes ReasonTypeId { get; private set; }
        public DelegateStatusTypes StatusTypeId { get; private set; }
        public string Description { get; private set; }
    }
}