using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;

namespace NgCrm.BasicInfoService.Domain.Organizations.Dtos
{
    public class OrganizationBriefDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public OrganizationTypes OrganizationTypeId { get; set; }
        public string OrganizationTypeTitle { get; set; }
        public int? Code { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public int PositionCount { get; set; }

    }
}
