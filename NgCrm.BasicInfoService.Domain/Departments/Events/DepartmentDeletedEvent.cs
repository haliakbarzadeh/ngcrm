using Goldiran.Framework.Domain.Events;

namespace NgCrm.BasicInfoService.Domain.Departments.Events
{
    public class DepartmentDeletedEvent : DeletedDomainEvent
    {
        public DepartmentDeletedEvent(long id, Guid businessId, string title, string name, DateTime? deletedAt)
            : base(id, businessId)
        {
            Title = title;
            Name = name;
            DeletedAt = deletedAt;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public DateTime? DeletedAt { get; private set; }
    }
}