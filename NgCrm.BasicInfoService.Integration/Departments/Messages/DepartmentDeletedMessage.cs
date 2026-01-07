using Goldiran.Framework.Domain.Attributes;
using Goldiran.Framework.Domain.IntegrationEvents;

namespace NgCrm.BasicInfoService.Integration.Departments.Messages
{
    [EventPath("NgCrm.BasicInfoService.Domain.Departments.Events.DepartmentDeletedEvent")]
    public class DepartmentDeletedMessage : IntegrationMessage
    {
        public Guid BusinessId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
    }
}