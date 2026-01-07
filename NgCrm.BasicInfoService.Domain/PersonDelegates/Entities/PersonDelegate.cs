using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Events;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Entities
{
    [Auditable]
    public class PersonDelegate : AggregateRoot
    {
        public PersonDelegate(long assignerPersonId, long assignerPositionId, long delegatePersonId, DateTime fromDate, DateTime? toDate, DelegateReasonTypes reasonTypeId, string description, long createPersonId)
        {
            AssignerPersonId = assignerPersonId;
            AssignerPositionId = assignerPositionId;
            DelegatePersonId = delegatePersonId;
            FromDate = fromDate;
            ToDate = toDate;
            ReasonTypeId = reasonTypeId;
            StatusTypeId = DelegateStatusTypes.Submitted;
            Description = description;
            CreatePersonId = createPersonId;

            AddEvent(new PersonDelegateCreatedEvent(BusinessId, assignerPersonId, assignerPositionId, delegatePersonId, fromDate, toDate, reasonTypeId, StatusTypeId, description, CreatedAt));
        }

        public void Update(long assignerPersonId, long assignerPositionId, long delegatePersonId, DateTime fromDate, DateTime? toDate, DelegateReasonTypes reasonTypeId, DelegateStatusTypes statusTypeId, string description)
        {
            AssignerPersonId = assignerPersonId;
            AssignerPositionId = assignerPositionId;
            DelegatePersonId = delegatePersonId;
            FromDate = fromDate;
            ToDate = toDate;
            ReasonTypeId = reasonTypeId;
            StatusTypeId = statusTypeId;
            ModifiedAt = DateTime.Now;
            Description = description;

            AddEvent(new PersonDelegateUpdatedEvent(Id, BusinessId, ModifiedAt.Value, assignerPersonId, assignerPositionId, delegatePersonId, fromDate, toDate, reasonTypeId, statusTypeId, description));
        }

        public void Delete()
        {
            Archive();

            AddEvent(new PersonDelegateDeletedEvent(Id, BusinessId, AssignerPersonId, DelegatePersonId));
        }

        public long AssignerPersonId { get; private set; }
        public long AssignerPositionId { get; private set; }
        public long DelegatePersonId { get; private set; }
        public long CreatePersonId { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime? ToDate { get; private set; }
        public DelegateReasonTypes ReasonTypeId { get; private set; }
        public DelegateStatusTypes StatusTypeId { get; private set; }
        public string Description { get; private set; }


    }
}