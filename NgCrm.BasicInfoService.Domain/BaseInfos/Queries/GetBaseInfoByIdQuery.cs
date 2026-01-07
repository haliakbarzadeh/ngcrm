using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;

namespace NgCrm.BasicInfoService.Domain.BaseInfos.Queries
{
    public class GetBaseInfoByIdQuery : BaseQueryRequest, IRequest<BaseInfoDto>
    {
        public long Id { get; set; }
    }

}
