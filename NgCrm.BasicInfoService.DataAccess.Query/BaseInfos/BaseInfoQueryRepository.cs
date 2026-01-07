using Goldiran.Framework.Domain.Models;
using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using Mapster;
using Goldiran.Framework.EFCore.Common;

namespace NgCrm.BasicInfoService.DataAccess.Query.BaseInfos
{
    public class BaseInfoQueryRepository : QueryRepository<BaseInfoReadModel, BasicInfoQueryContext>, IBaseInfoQueryRepository
    {
        public BaseInfoQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {
            
        }
        public async Task<Paged<BaseInfoDto>> GetBaseInfos(GetBaseInfoQuery filter, CancellationToken cancellationToken)
        {
            var result = await DbContext.BaseInfos.AsNoTracking()
                            .Where(c => (filter.BaseInfoTypeId!=null ?c.BaseInfoTypeId==filter.BaseInfoTypeId : true) &&
                                        (filter.IsActive!=null? c.IsActive==filter.IsActive : true))
                            .OrderByDescending(x => x.Id)
                            .ProjectToType<BaseInfoDto>()
                            .ToPagedListAsync(filter.FilterInfo,cancellationToken);

            return result;
        }
    }
}
