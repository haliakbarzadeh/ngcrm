using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.BaseInfos
{
    public class BaseInfoCommandRepository : CommandRepository<BaseInfo, BasicInfoCommandContext>, IBaseInfoCommandRepository
    {
        public BaseInfoCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
