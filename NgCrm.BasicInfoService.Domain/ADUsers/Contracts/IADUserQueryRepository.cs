using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.ADUsers.Dtos;
using NgCrm.BasicInfoService.Domain.ADUsers.Queries;
using NgCrm.BasicInfoService.Domain.ADUsers.ReadModels;
using System.Linq.Expressions;

namespace NgCrm.BasicInfoService.Domain.ADUsers.Contracts
{
    public interface IADUserQueryRepository : IQueryRepository<ADUserReadModel>
    {
        Task<Paged<ADUserReadModel>> GetPagedByFilterAsync(GetADUserQuery getADUserQuery, CancellationToken cancellationToken);
        Task<IEnumerable<SelectItemDto>> GetADUserSelectListAsync(GetADUserSelectListQuery request, CancellationToken cancellationToken);
    }
}
