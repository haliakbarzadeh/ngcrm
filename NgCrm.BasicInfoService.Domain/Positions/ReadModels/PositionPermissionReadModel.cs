using Goldiran.Framework.Domain;

namespace NgCrm.BasicInfoService.Domain.Positions.ReadModels
{
    public class PositionPermissionReadModel : ReadModel
    {
        public long PositionId { get; set; }
        public long PermissionId { get; set; }
    }
}
