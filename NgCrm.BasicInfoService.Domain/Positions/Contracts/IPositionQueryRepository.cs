using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Queries;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Positions.Contracts
{
    public interface IPositionQueryRepository : IQueryRepository<PositionReadModel>
    {
        Task<Paged<PositionBriefDto>> GetPagedByFilterAsync(GetPositionQuery getPositionQuery,
            CancellationToken cancellationTokens);

        Task<IEnumerable<PositionReadModel>> GetAllByOrganizationIdAsync(long organizationId, CancellationToken cancellationToken);
        Task<IEnumerable<PositionReadModel>> GetAllByWorkspaceIdAsync(long workspaceId, CancellationToken cancellationToken);
        Task<IEnumerable<PositionReadModel>> GetByIdsAsync(IEnumerable<long> ids, CancellationToken cancellationToken);
        Task<IEnumerable<SelectItemDto>> GetPositionsByOrganizationIdSelectListAsync(long organizationId, CancellationToken cancellationToken);
        Task<IEnumerable<SelectItemDto>> GetPositionsSelectListAsync(CancellationToken cancellationToken);

        Task<Paged<PositionBriefDto>> GetByPersonIdPagedByFilterAsync(GetPositionByPersonIdQuery getPositionByPersonIdQuery,
          CancellationToken cancellationTokens);
    }
}
