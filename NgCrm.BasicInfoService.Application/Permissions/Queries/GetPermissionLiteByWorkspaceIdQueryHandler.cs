using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Queries;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Permissions.Queries
{
    public class GetPermissionLiteByWorkspaceIdQueryHandler : IRequestHandler<GetPermissionLiteByWorkspaceIdQuery, IEnumerable<PermissionLiteDto>>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;

        public GetPermissionLiteByWorkspaceIdQueryHandler(IWorkspaceQueryRepository workspaceQueryRepository,
            IPermissionQueryRepository permissionQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
        }

        public async Task<IEnumerable<PermissionLiteDto>> Handle(GetPermissionLiteByWorkspaceIdQuery request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceQueryRepository.GetByIdAsync(request.WorkspaceId, cancellationToken, e => e.WorkspacePermissions);

            if (workspace is null)
                throw new KeyNotFoundException("فضای کاری یافت نشد.");

            var permissions = await _permissionQueryRepository.GetAllAsync(cancellationToken);
            var permissionIds = workspace.WorkspacePermissions.Select(x => x.PermissionId).ToList();

            var result = permissions.Select(e=>new PermissionLiteDto
            {
                Id = e.Id,
                Title = e.Title,
                ParentId = e.ParentId,
                IsSelect = permissionIds.Contains(e.Id),
            }).ToList();

            return result;
        }
    }
}
