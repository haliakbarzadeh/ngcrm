using Goldiran.Framework.Domain.Enums;
using Goldiran.Framework.EFCore.Audits;
using Goldiran.Framework.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;
using NgCrm.BasicInfoService.Domain.Workspaces.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Workspaces.Audits
{
    public class WorkspaceAuditService : AuditService<BasicInfoQueryContext>, IWorkspaceAuditService
    {
        public WorkspaceAuditService(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<long>> GetPermissions(long workspaceId, DateTime targetDate, CancellationToken cancellationToken)
        {
            var lastWorkspaceChange = await DbContext.AuditLogs
                .Where(x => x.EntityName == nameof(Workspace)
                    && (x.ChangeType == ChangeTypes.Added || x.ChangeType == ChangeTypes.Modified)
                    && x.EntityId == workspaceId
                    && x.CreatedAt <= targetDate)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

            if (lastWorkspaceChange == null)
                return Enumerable.Empty<long>();

            var workspacePermissions = await DbContext.AuditLogs
                .Where(x => x.EntityName == nameof(WorkspacePermission)
                    && DbFunctionExtensions.JsonValue(x.NewValues, "$.WorkspaceId") == workspaceId.ToString()
                    && x.ChangeType == ChangeTypes.Added
                    && x.TransactionId == lastWorkspaceChange.TransactionId)
                .DeserializeAsAsync<WorkspacePermissionReadModel>(cancellationToken);

            return workspacePermissions.Select(x => x.NewObject.PermissionId);
        }
    }
}
