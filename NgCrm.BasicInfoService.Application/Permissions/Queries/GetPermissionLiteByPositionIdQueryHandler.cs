using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Permissions.Queries
{
    public class GetPermissionLiteByPositionIdQueryHandler : IRequestHandler<GetPermissionLiteByPositionIdQuery, IEnumerable<PermissionLiteDto>>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;
        private readonly IPositionQueryRepository _positionQueryRepository;

        public GetPermissionLiteByPositionIdQueryHandler(IWorkspaceQueryRepository workspaceQueryRepository,
            IPermissionQueryRepository permissionQueryRepository,
            IPositionQueryRepository positionQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<IEnumerable<PermissionLiteDto>> Handle(GetPermissionLiteByPositionIdQuery request, CancellationToken cancellationToken)
        {
            var position = await _positionQueryRepository.GetByIdAsync(request.PositionId, cancellationToken, e => e.PositionPermissions);

            if (position is null)
                throw new KeyNotFoundException("سمت یافت نشد.");

            var workspace = await _workspaceQueryRepository.GetByIdAsync(position.WorkspaceId, cancellationToken, e => e.WorkspacePermissions);
            var permissionIds = workspace.WorkspacePermissions.Select(x => x.PermissionId);

            var permissions = await _permissionQueryRepository.GetByIdsAsync(permissionIds, cancellationToken);

            var result = permissions.Select(e=>new PermissionLiteDto
            {
                Id = e.Id,
                Title = e.Title,
                ParentId = e.ParentId,
                IsSelect = position.PositionPermissions.Any(q=>q.PermissionId == e.Id),
            }).ToList();

            return result;
        }
    }
}
