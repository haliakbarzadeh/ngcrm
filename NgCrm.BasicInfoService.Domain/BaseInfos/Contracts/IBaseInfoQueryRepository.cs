using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;

namespace NgCrm.BasicInfoService.Domain.BaseInfos.Contracts
{
    public interface IBaseInfoQueryRepository : IQueryRepository<BaseInfoReadModel>
    {
        public Task<Paged<BaseInfoDto>> GetBaseInfos(GetBaseInfoQuery filter, CancellationToken cancellationToken);
    }
}
