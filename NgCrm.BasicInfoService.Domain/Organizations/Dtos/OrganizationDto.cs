using Goldiran.Framework.Domain;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Organizations.Dtos
{
    public class OrganizationDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public OrganizationTypes OrganizationTypeId { get; set; }
        public string OrganizationTypeTitle { get; set; }
        public int? Code { get; set; }
        public string Address { get; set; }
        public HierarchyId? Hierarchy { get; set; }
        public bool IsActive { get; set; }

        public int PositionCount => PositionDtos == null ? 0 : PositionDtos.Count();

        public IEnumerable<PositionDto> PositionDtos { get; set; }
    }
}
