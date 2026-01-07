using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Roles.Dtos
{
    public class RoleBriefDto : Dto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
