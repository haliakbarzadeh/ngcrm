using Goldiran.Framework.Domain.Contracts;

namespace NgCrm.BasicInfoService.Domain.Positions.Contracts
{
    public interface IPositionAuditService : IAuditService
    {
        Task<IEnumerable<long>> GetPermissionHistory(long positionId, DateTime targetDate, CancellationToken cancellationToken);
    }
}
