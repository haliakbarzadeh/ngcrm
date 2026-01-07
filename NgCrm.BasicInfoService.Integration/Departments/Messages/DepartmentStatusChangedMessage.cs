using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.Departments.Messages
{
    [EventPath("NgCrm.BasicInfoService.Domain.Departments.Events.DepartmentStatusChangedEvent")]
    public class DepartmentStatusChangedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsActive { get; set; }
    }
}