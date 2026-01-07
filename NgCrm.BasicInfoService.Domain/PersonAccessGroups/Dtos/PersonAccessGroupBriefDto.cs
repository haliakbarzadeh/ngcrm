using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos
{
    public class PersonAccessGroupBriefDto : Dto
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string PersonName { get; set; }
        public long AccessGroupId { get; set; }
        public string AccessGroupTitle { get; set; }
    }
}