using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Dtos;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.Users.Dtos;
using NgCrm.BasicInfoService.Domain.Users.Queries;
using NgCrm.BasicInfoService.Domain.Users.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Users.Contracts
{
    public interface IUserQueryRepository : IQueryRepository<UserReadModel>
    {
        Task<IEnumerable<UserReadModel>> GetByIdsAsync(IEnumerable<long> userIds, CancellationToken cancellationToken);
        Task<Paged<UserBriefDto>> GetPagedByFilterAsync(GetUserQuery getUserQuery, CancellationToken cancellationToken);

        Task<UserReadModel> GetByUserNameAsync(string userName, CancellationToken cancellationToken);
        Task<IEnumerable<SelectItemDto>> GetPositionsByUserIdAsync(long userId, CancellationToken cancellationToken);
        Task<UserReadModel?> GetByIdAsync(long userId, CancellationToken cancellationToken);
        Task<IEnumerable<SelectItemDto>> GetUserSelectList(GetUserSelectListQuery request, CancellationToken cancellationToken);
    }
}
