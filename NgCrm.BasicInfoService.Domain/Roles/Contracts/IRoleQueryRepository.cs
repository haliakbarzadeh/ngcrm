using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Roles.Contracts
{
    public interface IRoleQueryRepository : IQueryRepository<RoleReadModel>
    {
    }
}
