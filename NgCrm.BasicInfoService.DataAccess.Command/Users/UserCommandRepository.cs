using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Users
{
    public class UserCommandRepository : CommandRepository<User, BasicInfoCommandContext>, IUserCommandRepository
    {
        public UserCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
