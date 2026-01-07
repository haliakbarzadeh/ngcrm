using Goldiran.Framework.Domain.Contracts;

namespace NgCrm.BasicInfoService.Domain.Workspaces.Contracts
{
    public interface IWorkspaceAuditService : IAuditService
    {
        Task<IEnumerable<long>> GetPermissions(long workspaceId, DateTime targetDate, CancellationToken cancellationToken);
    }
}
