using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Permissions.Enums;
namespace NgCrm.BasicInfoService.Domain.Permissions.ReadModels
{
    public class PermissionReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public HierarchyId Hierarchy { get; set; }
        public PermissionTypes PermissionTypeId { get; set; }
        public int? SortOrder { get; set; }
        public string Route { get; set; }
        public string Icon { get; set; }
    }
}
