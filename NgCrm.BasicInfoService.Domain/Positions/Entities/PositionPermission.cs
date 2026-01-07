using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
namespace NgCrm.BasicInfoService.Domain.Positions.Entities;

[Auditable]
public class PositionPermission : Entity
{
    public PositionPermission(long positionId, long permissionId)
    {
        PositionId = positionId;
        PermissionId = permissionId;

        //AddEvent(new WorkspacePermissionCreatedEvent(BusinessId, workspaceId, permissionId, CreatedAt));
    }


    public long PositionId { get; private set; }
    public long PermissionId { get; private set; }
}
