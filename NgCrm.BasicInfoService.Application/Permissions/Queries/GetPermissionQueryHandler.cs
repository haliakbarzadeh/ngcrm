using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Queries;

namespace NgCrm.BasicInfoService.Application.Permissions.Queries
{
    public class GetPermissionQueryHandler : IRequestHandler<GetPermissionQuery, IEnumerable<PermissionBriefDto>>
    {
        private readonly IPermissionQueryRepository _permissionQueryRepository;

        public GetPermissionQueryHandler(IPermissionQueryRepository permissionQueryRepository)
        {
            _permissionQueryRepository = permissionQueryRepository;
        }

        public async Task<IEnumerable<PermissionBriefDto>> Handle(GetPermissionQuery request, CancellationToken cancellationToken)
        {
            return (await _permissionQueryRepository.GetAllAsync(cancellationToken)).Adapt<IEnumerable<PermissionBriefDto>>();
        }
    }
}
