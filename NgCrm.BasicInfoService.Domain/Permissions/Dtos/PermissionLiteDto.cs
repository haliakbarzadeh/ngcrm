using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Permissions.Dtos
{
    public class PermissionLiteDto : Dto
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public bool IsSelect { get; set; }
    }
}
