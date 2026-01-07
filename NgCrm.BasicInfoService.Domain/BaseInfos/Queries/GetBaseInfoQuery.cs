using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;
using NgCrm.BasicInfoService.Domain.Common.Enums;

namespace NgCrm.BasicInfoService.Domain.BaseInfos.Queries
{
    public class GetBaseInfoQuery : BaseQueryRequest, IRequest<Paged<BaseInfoDto>>
    {
        public BaseInfoTypes? BaseInfoTypeId { get; set; }
        public bool? IsActive { get; set; }

    }
}
