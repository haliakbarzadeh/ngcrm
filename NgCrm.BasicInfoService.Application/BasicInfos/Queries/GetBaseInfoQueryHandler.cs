using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Queries
{
    public class GetBaseInfoQueryHandler : IRequestHandler<GetBaseInfoQuery, Paged<BaseInfoDto>>
    {
        private readonly IBaseInfoQueryRepository _BaseInfoQueryRepository;

        public GetBaseInfoQueryHandler(IBaseInfoQueryRepository BaseInfoQueryRepository)
        {
            _BaseInfoQueryRepository = BaseInfoQueryRepository;
        }

        public async Task<Paged<BaseInfoDto>> Handle(GetBaseInfoQuery request, CancellationToken cancellationToken)
        {
            return await _BaseInfoQueryRepository.GetBaseInfos(request, cancellationToken);
        }
    }
}
