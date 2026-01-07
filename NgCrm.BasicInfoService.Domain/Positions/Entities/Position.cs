using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Positions.Enums;

namespace NgCrm.BasicInfoService.Domain.Positions.Entities;

[Auditable]
public class Position : AggregateRoot
{
    public Position(string title, string name, long? parentId, long organizationId, long workspaceId, PositionTypes positionTypeId, bool isActive)
    {
        Title = title;
        Name = name;
        ParentId = parentId;
        OrganizationId = organizationId;
        WorkspaceId = workspaceId;
        PositionTypeId = positionTypeId;
        IsActive = isActive;

        //AddEvent(new PositionCreatedEvent(BusinessId, title, name, organizationId, workspaceId, parentId, positionTypeId, CreatedAt));
    }


    public void Update(string title, string name, long? parentId, long organizationId, long workspaceId, PositionTypes positionTypeId, bool isActive)
    {
        Title = title;
        Name = name;
        ParentId = parentId;
        OrganizationId = organizationId;
        WorkspaceId = workspaceId;
        PositionTypeId = positionTypeId;
        IsActive = isActive;

        ModifiedAt = DateTime.Now;
    }

    public void SetPositionPermissions(IEnumerable<PositionPermission> positionPermissions)
    {
        PositionPermissions = positionPermissions.ToList();
        ModifiedAt = DateTime.Now;
    }

    public void ToggleIsActive()
    {
        IsActive = !IsActive;
        ModifiedAt = DateTime.Now;
    }


    public string Title { get; private set; }
    public string Name { get; private set; }
    public long OrganizationId { get; private set; }
    public long WorkspaceId { get; private set; }
    public long? ParentId { get; private set; }
    public PositionTypes PositionTypeId { get; private set; }
    public HierarchyId Hierarchy { get; private set; }
    public bool IsActive { get; private set; }

    public virtual ICollection<PositionPermission> PositionPermissions { get; private set; } = new List<PositionPermission>();
}
