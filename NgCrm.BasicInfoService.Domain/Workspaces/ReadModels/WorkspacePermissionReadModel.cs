using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Workspaces.ReadModels
{
    public class WorkspacePermissionReadModel : ReadModel
    {
        public long WorkspaceId { get; set; }
        public long PermissionId { get; set; }
    }
}
