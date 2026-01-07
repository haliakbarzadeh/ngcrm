using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Departments.Events;

namespace NgCrm.BasicInfoService.Domain.Departments.Entities
{
    public class Department : AggregateRoot
    {
        public Department(string title, string name, long? parentId, string description, bool isActive)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            Description = description;
            IsActive = isActive;

            AddEvent(new DepartmentCreatedEvent(BusinessId, title, name, parentId, description, isActive, CreatedAt));
        }

        public void Update(string title, string name, long? parentId, string description, bool isActive)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            Description = description;
            IsActive = isActive;
            ModifiedAt = DateTime.Now;

            AddEvent(new DepartmentUpdatedEvent(Id, BusinessId, ModifiedAt.Value, title, name, parentId, description, isActive));
        }

        public void Delete()
        {
            Archive();

            AddEvent(new DepartmentDeletedEvent(Id, BusinessId, Title, Name, DateTime.Now));
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public long? ParentId { get; private set; }
        public string Description { get; private set; }
        public bool IsActive { get; private set; }

        public virtual Department Parent { get; private set; }
        public virtual ICollection<Department> Children { get; private set; } = new List<Department>();
    }
}