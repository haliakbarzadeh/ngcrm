using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Workspaces.ReadModels
{
    public class WorkspaceReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public bool IsSystem { get; set; }
        public string Description { get; set; }

        public virtual ICollection<WorkspacePermissionReadModel> WorkspacePermissions { get; set; } = new List<WorkspacePermissionReadModel>();
    }
}
