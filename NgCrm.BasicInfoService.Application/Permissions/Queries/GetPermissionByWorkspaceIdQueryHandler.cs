using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.Queries;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;
using NgCrm.BasicInfoService.Domain.Persons.Entities;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Permissions.Queries
{
    public class GetPermissionByWorkspaceIdQueryHandler : IRequestHandler<GetPermissionByWorkspaceIdQuery, IEnumerable<PermissionBriefDto>>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;

        public GetPermissionByWorkspaceIdQueryHandler(IWorkspaceQueryRepository workspaceQueryRepository,
            IPermissionQueryRepository permissionQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
        }

        public async Task<IEnumerable<PermissionBriefDto>> Handle(GetPermissionByWorkspaceIdQuery request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceQueryRepository.GetByIdAsync(request.WorkspaceId, cancellationToken, e => e.WorkspacePermissions);

            if (workspace is null)
                throw new KeyNotFoundException("فضای کاری یافت نشد.");

            var permissionIds = workspace.WorkspacePermissions.Select(x => x.PermissionId).ToList();
            return (await _permissionQueryRepository.GetByIdsAsync(permissionIds, cancellationToken)).Adapt<IEnumerable<PermissionBriefDto>>();
        }
    }
}
