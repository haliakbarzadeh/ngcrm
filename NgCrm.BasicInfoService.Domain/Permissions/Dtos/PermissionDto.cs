using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Permissions.Enums;

namespace NgCrm.BasicInfoService.Domain.Permissions.Dtos
{
    public class PermissionDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public PermissionTypes PermissionTypeId { get; set; }
        public int? SortOrder { get; set; }
        public string Route { get; set; }
        public string Icon { get; set; }
        public long? ParentId { get; set; }
        public HierarchyId Hierarchy { get; set; }
    }
}
