using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Permissions.Enums;

namespace NgCrm.BasicInfoService.Domain.Permissions.Entities
{
    [Auditable]
    public class Permission : AggregateRoot
    {
        public Permission(string title, string name, long? parentId, PermissionTypes permissionTypeId, int? sortOrder, string route, string icon)
        {
            Title = title;
            Name = name;
            ParentId = parentId;
            PermissionTypeId = permissionTypeId;
            SortOrder = sortOrder;
            Route = route;
            Icon = icon;

            //AddEvent(new PermissionCreatedEvent(BusinessId, title, name, parentId, permissionTypeId, sortOrder, route, icon, CreatedAt));
        }


        public string Title { get; private set; }
        public string Name { get; private set; }
        public PermissionTypes PermissionTypeId { get; private set; }
        public int? SortOrder { get; private set; }
        public string Route { get; private set; }
        public string Icon { get; private set; }
        public long? ParentId { get; private set; }
        public HierarchyId Hierarchy { get; private set; }

        //public virtual ICollection<Permission> InverseParent { get; private set; } = new List<Permission>();

        public virtual Permission Parent { get; private set; }

        //public virtual ICollection<WorkspacePermission> WorkspacePermissions { get; private set; } = new List<WorkspacePermission>();
    }
}
