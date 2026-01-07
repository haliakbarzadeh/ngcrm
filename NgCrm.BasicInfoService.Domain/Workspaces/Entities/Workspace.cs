using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Entities;

[Auditable]
public class Workspace : AggregateRoot
{
    public Workspace(string title, string name, string description)
    {
        Title = title;
        Name = name;
        IsSystem = false;
        Description = description;
        //AddEvent(new WorkspaceCreatedEvent(BusinessId, title, name,IsSystem , CreatedAt));
    }

    public void Update(string title, string name, string description)
    {
        Title = title;
        Name = name;
        Description = description;
        ModifiedAt = DateTime.Now;
    }


    public void SetWorkspacePermissions(IEnumerable<WorkspacePermission> workspacePermissions)
    {
        WorkspacePermissions = workspacePermissions.ToList();
        ModifiedAt = DateTime.Now;
    }


    public string Title { get; private set; }
    public string Name { get; private set; }
    public bool IsSystem { get; private set; } = false;
    public string Description { get; private set; }


    public virtual ICollection<WorkspacePermission> WorkspacePermissions { get; private set; } = new List<WorkspacePermission>();
}
