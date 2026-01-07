using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Roles.Contracts;
using NgCrm.BasicInfoService.Domain.Roles.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Roles
{
    public class RoleQueryRepository : QueryRepository<RoleReadModel, BasicInfoQueryContext>, IRoleQueryRepository
    {
        public RoleQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }
    }
}
