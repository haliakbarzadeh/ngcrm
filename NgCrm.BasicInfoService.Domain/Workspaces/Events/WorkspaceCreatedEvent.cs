using Goldiran.Framework.Domain.Events;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Events
{
    public class WorkspaceCreatedEvent : CreatedDomainEvent
    {
        public WorkspaceCreatedEvent(Guid businessId,
                              string title,
                              string name,
                              bool isSystem,
                              DateTime createdAt)
          : base(businessId, createdAt)
        {
            Title = title;
            Name = name;
            IsSystem = isSystem;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public bool IsSystem { get; private set; }
    }
}
