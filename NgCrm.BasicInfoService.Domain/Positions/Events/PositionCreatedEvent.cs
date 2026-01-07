using Goldiran.Framework.Domain.Events;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Positions.Enums;

namespace NgCrm.BasicInfoService.Domain.Positions.Events
{
    public class PositionCreatedEvent : CreatedDomainEvent
    {
        public PositionCreatedEvent(Guid businessId,
                              string title,
                              string name,
                              long organizationId,
                              long workspaceId,
                              long? parentId,
                              PositionTypes positionTypeId,
                              DateTime createdAt)
          : base(businessId, createdAt)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            OrganizationId = organizationId;
            WorkspaceId = workspaceId;
            PositionTypeId = positionTypeId;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public long OrganizationId { get; private set; }
        public long WorkspaceId { get; private set; }
        public long? ParentId { get; private set; }
        public PositionTypes PositionTypeId { get; private set; }
        public HierarchyId Hierarchy { get; private set; }

    }
}
