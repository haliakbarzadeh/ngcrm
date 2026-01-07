using Goldiran.Framework.Domain.Events;

namespace NgCrm.BasicInfoService.Domain.Departments.Events
{
    public class DepartmentUpdatedEvent : UpdatedDomainEvent
    {
        public DepartmentUpdatedEvent(long id, Guid businessId, DateTime modifiedAt, string title, string name, long? parentId, string description, bool isActive)
            : base(id, businessId, modifiedAt)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            Description = description;
            IsActive = isActive;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public long? ParentId { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }
    }
}