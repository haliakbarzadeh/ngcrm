using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Common;
using Goldiran.Framework.EFCore.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Queries;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Positions
{
    public class PositionQueryRepository : QueryRepository<PositionReadModel, BasicInfoQueryContext>, IPositionQueryRepository
    {
        public PositionQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<PositionReadModel>> GetAllByOrganizationIdAsync(long organizationId, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => e.OrganizationId == organizationId)
                .ToListAsync(cancellationToken);

            return list;
        }
        public async Task<IEnumerable<PositionReadModel>> GetAllByWorkspaceIdAsync(long workspaceId, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => e.WorkspaceId == workspaceId)
                .ToListAsync(cancellationToken);

            return list;
        }

        public async Task<Paged<PositionBriefDto>> GetPagedByFilterAsync(GetPositionQuery getPositionQuery, CancellationToken cancellationToken)
        {
            var query = EntitySet.AsQueryable();

            if (!string.IsNullOrEmpty(getPositionQuery.Title))
                query = query.Where(e => e.Title.Contains(getPositionQuery.Title));

            if (getPositionQuery.OrganizationIds is not null && getPositionQuery.OrganizationIds.Count > 0)
                query = query.Where(e => getPositionQuery.OrganizationIds.Contains(e.OrganizationId));

            if (getPositionQuery.WorkspaceIds is not null && getPositionQuery.WorkspaceIds.Count > 0)
                query = query.Where(e => getPositionQuery.WorkspaceIds.Contains(e.WorkspaceId));

            if (getPositionQuery.PositionTypeIds is not null && getPositionQuery.PositionTypeIds.Count > 0)
                query = query.Where(e => getPositionQuery.PositionTypeIds.Contains(e.PositionTypeId));

            if (getPositionQuery.IsActive is not null)
                query = query.Where(e => e.IsActive == getPositionQuery.IsActive);           

            var list = await query.ProjectToType<PositionBriefDto>()
                .ToPagedListAsync(getPositionQuery.FilterInfo, cancellationToken);

            return list;
        }
        public async Task<IEnumerable<PositionReadModel>> GetByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => ids.Contains(e.Id))
                .Include(e => e.PositionPermissions)
                .Include(e => e.Organization)
                .Include(e => e.Workspace)
                .ToListAsync(cancellationToken); 
            
            return list;
        }

        public async Task<IEnumerable<SelectItemDto>> GetPositionsByOrganizationIdSelectListAsync(long organizationId, CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Where(e => e.OrganizationId == organizationId)
                .Select(e => new SelectItemDto { Id = e.Id, Title = e.Title })
                .ToListAsync(cancellationToken);

            return list;
        }

        public async Task<IEnumerable<SelectItemDto>> GetPositionsSelectListAsync(CancellationToken cancellationToken)
        {
            var list = await EntitySet
                .Select(e => new SelectItemDto { Id = e.Id, Title = e.Title })
                .ToListAsync(cancellationToken);

            return list;
        }


        public async Task<Paged<PositionBriefDto>> GetByPersonIdPagedByFilterAsync(GetPositionByPersonIdQuery getPositionByPersonIdQuery , CancellationToken cancellationToken)
        {
            var positionIds = await DbContext.Persons
                .Where(e => e.Id == getPositionByPersonIdQuery.PersonId)
                .Include(e => e.PersonPositions)
                .SelectMany(e => e.PersonPositions.Where(q => q.IsActive && (!q.EndDate.HasValue || q.EndDate > DateTime.Now)).Select(q => q.PositionId))
                .ToListAsync(cancellationToken);

            var query = EntitySet.Where(e=> positionIds.Contains(e.Id)).AsQueryable();

            if (!string.IsNullOrEmpty(getPositionByPersonIdQuery.Title))
                query = query.Where(e => e.Title.Contains(getPositionByPersonIdQuery.Title));

            if (getPositionByPersonIdQuery.OrganizationIds is not null && getPositionByPersonIdQuery.OrganizationIds.Count > 0)
                query = query.Where(e => getPositionByPersonIdQuery.OrganizationIds.Contains(e.OrganizationId));

            if (getPositionByPersonIdQuery.WorkspaceIds is not null && getPositionByPersonIdQuery.WorkspaceIds.Count > 0)
                query = query.Where(e => getPositionByPersonIdQuery.WorkspaceIds.Contains(e.WorkspaceId));

            if (getPositionByPersonIdQuery.PositionTypeIds is not null && getPositionByPersonIdQuery.PositionTypeIds.Count > 0)
                query = query.Where(e => getPositionByPersonIdQuery.PositionTypeIds.Contains(e.PositionTypeId));

            if (getPositionByPersonIdQuery.IsActive is not null)
                query = query.Where(e => e.IsActive == getPositionByPersonIdQuery.IsActive);

            var list = await query.ProjectToType<PositionBriefDto>()
                .ToPagedListAsync(getPositionByPersonIdQuery.FilterInfo, cancellationToken);

            return list;
        }

    }
}
