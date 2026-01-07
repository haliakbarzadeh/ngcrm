using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.AccessGroups.Queries;
using NgCrm.BasicInfoService.Domain.AccessGroups.ReadModels;
using NgCrm.BasicInfoService.Domain.Positions.Queries;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Contracts
{
    public interface IAccessGroupQueryRepository : IQueryRepository<AccessGroupReadModel>
    {
        Task<Paged<AccessGroupBriefDto>> GetPagedByFilterAsync(GetAccessGroupQuery getAccessGroupQuery,
            CancellationToken cancellationToken);
        Task<IEnumerable<SelectItemDto>> GetAccessGroupsSelectListAsync(GetAccessGroupsSelectListQuery getAccessGroupsSelectListQuery, CancellationToken cancellationToken);
    }
}
