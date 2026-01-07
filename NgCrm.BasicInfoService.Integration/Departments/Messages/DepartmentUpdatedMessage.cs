using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.Departments.Messages
{
    [EventPath("NgCrm.BasicInfoService.Domain.Departments.Events.DepartmentUpdatedEvent")]
    public class DepartmentUpdatedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}