using Goldiran.Framework.Domain.Events;

namespace NgCrm.BasicInfoService.Domain.Roles.Events
{
    public class RoleCreatedEvent : CreatedDomainEvent
    {
        public RoleCreatedEvent(Guid businessId,
                                string title,
                                string name,
                                long? parentId,
                                DateTime createdAt)
            : base(businessId, createdAt)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public long? ParentId { get; private set; }

    }
}
