using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Queries;
using NgCrm.BasicInfoService.Domain.PersonDelegates.ReadModels;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts
{
    public interface IPersonDelegateQueryRepository : IQueryRepository<PersonDelegateReadModel>
    {
        Task<Paged<PersonDelegateReadModel>> GetPagedByFilterAsync(GetPersonDelegateQuery request, CancellationToken cancellationToken);
    }
}