using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Positions.Dtos
{
    public class PositionPermissionDto : Dto
    {
        public long PositionId { get; set; }
        public long PermissionId { get; set; }
    }
}
