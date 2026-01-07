using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Queries
{
    public class GetBaseInfoByIdQueryHandler : IRequestHandler<GetBaseInfoByIdQuery, BaseInfoDto>
    {
        private readonly IBaseInfoQueryRepository _BaseInfoQueryRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;

        public GetBaseInfoByIdQueryHandler(IBaseInfoQueryRepository BaseInfoQueryRepository,
            IPermissionQueryRepository permissionQueryRepository)
        {
            _BaseInfoQueryRepository = BaseInfoQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
        }

        public async Task<BaseInfoDto> Handle(GetBaseInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var BaseInfo = await _BaseInfoQueryRepository.GetByIdAsync(request.Id, cancellationToken);

            var BaseInfoDto = BaseInfo.Adapt<BaseInfoDto>();

            return BaseInfoDto;
        }
    }
}
