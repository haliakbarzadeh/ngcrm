using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.AccessGroups.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.AccessGroups
{
    public class AccessGroupCommandRepository : CommandRepository<AccessGroup, BasicInfoCommandContext>, IAccessGroupCommandRepository
    {
        public AccessGroupCommandRepository( BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
