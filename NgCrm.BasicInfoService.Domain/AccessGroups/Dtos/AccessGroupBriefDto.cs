using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Dtos
{
    public class AccessGroupBriefDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
    }
}