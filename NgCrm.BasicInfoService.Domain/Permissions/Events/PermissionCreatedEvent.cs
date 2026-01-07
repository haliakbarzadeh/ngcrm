using Goldiran.Framework.Domain.Events;
using NgCrm.BasicInfoService.Domain.Permissions.Enums;

namespace NgCrm.BasicInfoService.Domain.Permissions.Events
{
    public class PermissionCreatedEvent : CreatedDomainEvent
    {
        public PermissionCreatedEvent(Guid businessId,
                              string title,
                              string name,
                              long parentId,
                              PermissionTypes permissionTypeId,
                              int? sortOrder,
                              string route,
                              string icon,
                              DateTime createdAt)
          : base(businessId, createdAt)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            PermissionTypeId = permissionTypeId;
            SortOrder = sortOrder;
            Route = route;
            Icon = icon;
        }

        public string Title { get; private set; }
        public string Name { get; private set; }
        public long ParentId { get; private set; }
        public PermissionTypes PermissionTypeId { get; private set; }
        public int? SortOrder { get; private set; }
        public string Route { get; private set; }
        public string Icon { get; private set; }

    }
}
