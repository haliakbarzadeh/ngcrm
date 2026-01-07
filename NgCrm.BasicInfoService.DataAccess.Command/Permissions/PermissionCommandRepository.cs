using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Permissions
{
    public class PermissionCommandRepository : CommandRepository<Permission, BasicInfoCommandContext>, IPermissionCommandRepository
    {
        public PermissionCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
