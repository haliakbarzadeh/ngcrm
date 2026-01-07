using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;

namespace NgCrm.BasicInfoService.Domain.OrganizationHistories.Dtos
{
    public class OrganizationHistoryDto : Dto
    {
        public bool IsCurrent { get; set; }
        public IEnumerable<OrganizationBriefDto> OrganizationDtos { get; set; }
    }
}