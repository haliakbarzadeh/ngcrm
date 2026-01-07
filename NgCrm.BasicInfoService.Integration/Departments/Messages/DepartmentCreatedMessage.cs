using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.Departments.Messages
{
    [EventPath("NgCrm.BasicInfoService.Domain.Departments.Events.DepartmentCreatedEvent")]
    public class DepartmentCreatedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}