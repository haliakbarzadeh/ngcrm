using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.ADUsers.Contracts;
using NgCrm.BasicInfoService.Domain.ADUsers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.ADUsers
{
    public class ADUserCommandRepository : CommandRepository<ADUser, BasicInfoCommandContext>, IADUserCommandRepository
    {
        public ADUserCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
