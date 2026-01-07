using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;
using NgCrm.BasicInfoService.Domain.Positions.Enums;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Positions.ReadModels
{
    public class PositionReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long OrganizationId { get; set; }
        public long WorkspaceId { get; set; }
        public long? ParentId { get; set; }
        public PositionTypes PositionTypeId { get; set; }
        public HierarchyId Hierarchy { get; set; }
        public bool IsActive { get; set; }


        public virtual WorkspaceReadModel Workspace { get; set; }
        public virtual OrganizationReadModel Organization { get; set; }

        public virtual ICollection<PositionPermissionReadModel> PositionPermissions { get; set; } = new List<PositionPermissionReadModel>();

    }
}
