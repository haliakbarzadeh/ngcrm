
using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Persons.Dtos
{
    public class PersonPositionPermissionDto : Dto
    {
        public long PersonPositionId { get; set; }
        public long PermissionId { get; set; }
        public bool IsAllow { get; set; }
    }
}
