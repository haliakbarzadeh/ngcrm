using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.PersonDelegates.Messages
{
    [EventPath("NgCrm.BasicInfoService.Domain.PersonDelegates.Events.PersonDelegateCreatedEvent")]
    public class PersonDelegateCreatedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime CreatedAt { get; set; }
        public long AssignerPersonId { get; set; }
        public long AssignerPositionId { get; set; }
        public long DelegatePersonId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int ReasonTypeId { get; set; }
        public int StatusTypeId { get; set; }
    }
}