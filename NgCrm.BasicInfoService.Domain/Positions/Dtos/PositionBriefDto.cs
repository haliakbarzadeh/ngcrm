using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Positions.Enums;

namespace NgCrm.BasicInfoService.Domain.Positions.Dtos
{
    public class PositionBriefDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long OrganizationId { get; set; }
        public string OrganizationTitle { get; set; }
        public long WorkspaceId { get; set; }
        public string WorkspaceTitle { get; set; }
        public long? ParentId { get; set; }
        public PositionTypes PositionTypeId { get; set; }
        public string PositionTypeTitle { get; set; }
        public bool IsActive { get; set; }

    }
}
