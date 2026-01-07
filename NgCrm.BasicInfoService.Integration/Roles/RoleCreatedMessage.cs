using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.Roles
{
    [EventPath("NgCrm.BasicInfoService.Domain.Roles.Events.RoleCreatedEvent")]
    public class RoleCreatedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
