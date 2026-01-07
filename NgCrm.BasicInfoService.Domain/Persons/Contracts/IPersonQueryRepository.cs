using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Persons.Contracts
{
    public interface IPersonQueryRepository : IQueryRepository<PersonReadModel>
    {
        Task<Paged<PersonBriefDto>> GetPagedByFilterAsync(GetPersonQuery getPersonQuery,
            CancellationToken cancellationToken);

        Task<IEnumerable<PersonReadModel>> GetByPositionIdAsync(long id, CancellationToken cancellationToken);

        Task<PersonReadModel> GetPersonByIdAsync(long id, CancellationToken cancellationToken, long? positionId = null);

        Task<IEnumerable<SelectItemDto>> GetPersonSelectListAsync(GetPersonSelectListQuery request, CancellationToken cancellationToken);

        Task<IEnumerable<SelectItemDto>> GetPositionsByPersonIdAsync(long personId, CancellationToken cancellationToken);

        Task<IEnumerable<SelectItemDto>> GetMyChildPersonsAsync(long positionId, CancellationToken cancellationToken);
        Task<IEnumerable<PersonSummaryDto>> GetGetPersonSummaryAsync(GetPersonSummaryQuery request, CancellationToken cancellationToken);
    }
}
