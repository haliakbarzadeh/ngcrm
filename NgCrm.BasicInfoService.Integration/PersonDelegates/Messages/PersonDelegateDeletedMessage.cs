using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.PersonDelegates.Messages
{
    [EventPath("NgCrm.BasicInfoService.Domain.PersonDelegates.Events.PersonDelegateDeletedEvent")]
    public class PersonDelegateDeletedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime DeletedAt { get; set; }
        public long AssignerPersonId { get; set; }
        public long DelegatePersonId { get; set; }
    }
}