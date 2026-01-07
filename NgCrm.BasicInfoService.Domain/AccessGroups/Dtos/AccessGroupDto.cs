using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Dtos
{
    public class AccessGroupDto : Dto
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public IEnumerable<PersonAccessGroupDto> PersonAccessGroupDtos { get; set; }
    }

   
}