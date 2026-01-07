using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Dtos;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Dtos
{
    public class AccessGroupDetailDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }
        public IEnumerable<SelectItemDto> Persons { get; set; }
    }
}