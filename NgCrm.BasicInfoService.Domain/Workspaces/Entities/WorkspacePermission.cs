using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Entities
{
    [Auditable]
    public class WorkspacePermission : Entity
    {
        public WorkspacePermission(long workspaceId, long permissionId)
        {
            WorkspaceId = workspaceId;
            PermissionId = permissionId;

            //AddEvent(new WorkspacePermissionCreatedEvent(BusinessId, workspaceId, permissionId, CreatedAt));
        }

        public long WorkspaceId { get; private set; }
        public long PermissionId { get; private set; }
    }
}

