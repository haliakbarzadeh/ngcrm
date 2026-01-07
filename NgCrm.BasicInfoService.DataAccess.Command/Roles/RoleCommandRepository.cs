using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Roles.Contracts;
using NgCrm.BasicInfoService.Domain.Roles.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Roles
{
    public class RoleCommandRepository : CommandRepository<Role, BasicInfoCommandContext>, IRoleCommandRepository
    {
        public RoleCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
