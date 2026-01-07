using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Dtos;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.ReadModels;

namespace NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts
{
    public interface IPersonAccessGroupQueryRepository : IQueryRepository<PersonAccessGroupReadModel>
    {
        Task<IEnumerable<PersonAccessGroupReadModel>> GetByPersonIdAsync(long personId, CancellationToken cancellationToken);
        Task<IEnumerable<PersonAccessGroupReadModel>> GetByAccessGroupIdAsync(long accessGroupId, CancellationToken cancellationToken);
        Task<IEnumerable<PersonAccessGroupBriefDto>> GetPersonAccessGroupBriefDtosAsync(CancellationToken cancellationToken);
    }
}