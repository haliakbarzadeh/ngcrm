using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Organizations.ReadModels
{
    public class OrganizationReadModel : ReadModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public OrganizationTypes OrganizationTypeId { get; set; }
        public int? Code { get; set; }
        public string Address { get; set; }
        public HierarchyId? Hierarchy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<PositionReadModel> Positions { get; set; } = new List<PositionReadModel>();
    }
}
