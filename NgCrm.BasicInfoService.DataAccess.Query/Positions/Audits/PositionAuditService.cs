using Goldiran.Framework.Domain.Enums;
using Goldiran.Framework.EFCore.Audits;
using Goldiran.Framework.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Entities;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Positions.Audits
{
    public class PositionAuditService : AuditService<BasicInfoQueryContext>, IPositionAuditService
    {
        public PositionAuditService(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<long>> GetPermissionHistory(long positionId, DateTime targetDate, CancellationToken cancellationToken)
        {
            var lastPositionChange = await DbContext.AuditLogs
                .Where(x => x.EntityName == nameof(Position)
                    && (x.ChangeType == ChangeTypes.Added || x.ChangeType == ChangeTypes.Modified)
                    && x.EntityId == positionId
                    && x.CreatedAt <= targetDate)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefaultAsync(cancellationToken);

            if (lastPositionChange == null)
                return Enumerable.Empty<long>();

            var positionPermissions = await DbContext.AuditLogs
                .Where(x => x.EntityName == nameof(PositionPermission)
                    && DbFunctionExtensions.JsonValue(x.NewValues, "$.PositionId") == positionId.ToString()
                    && x.ChangeType == ChangeTypes.Added
                    && x.TransactionId == lastPositionChange.TransactionId)
                .DeserializeAsAsync<PositionPermissionReadModel>(cancellationToken);

            return positionPermissions.Select(x => x.NewObject.PermissionId);
        }
    }
}
