using Goldiran.Framework.Domain.Enums;
using Goldiran.Framework.EFCore.Audits;
using Goldiran.Framework.EFCore.Common;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Positions.Entities;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;
using NgCrm.BasicInfoService.Domain.Users.Contracts;

namespace NgCrm.BasicInfoService.DataAccess.Query.Users.Audits
{
    public class UserAuditService : AuditService<BasicInfoQueryContext>, IUserAuditService
    {
        public UserAuditService(BasicInfoQueryContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<long>> GetPermissions(long userId, DateTime targetDate, CancellationToken cancellationToken)
        {
            var result = new List<long>();

            var positionIds = await DbContext.Users.Include(x => x.Person).ThenInclude(x => x.PersonPositions)
                .Where(x => x.Id == userId)
                .SelectMany(x => x.Person.PersonPositions.Select(e => e.PositionId))
                .ToListAsync(cancellationToken);

            foreach (var positionId in positionIds)
            {
                var lastPositionChange = await DbContext.AuditLogs
                    .Where(x => x.EntityName == nameof(Position)
                        && (x.ChangeType == ChangeTypes.Added || x.ChangeType == ChangeTypes.Modified)
                        && x.EntityId == positionId
                        && x.CreatedAt <= targetDate)
                    .OrderByDescending(x => x.CreatedAt)
                    .FirstOrDefaultAsync(cancellationToken);

                if (lastPositionChange == null)
                    continue;

                var positionPermissions = await DbContext.AuditLogs
                    .Where(x => x.EntityName == nameof(PositionPermission)
                        && DbFunctionExtensions.JsonValue(x.NewValues, "$.PositionId") == positionId.ToString()
                        && x.ChangeType == ChangeTypes.Added
                        && x.TransactionId == lastPositionChange.TransactionId)
                    .DeserializeAsAsync<PositionPermissionReadModel>(cancellationToken);

                result.AddRange(positionPermissions.Select(x => x.NewObject.PermissionId));

            }

            return result.Distinct();
        }
    }
}