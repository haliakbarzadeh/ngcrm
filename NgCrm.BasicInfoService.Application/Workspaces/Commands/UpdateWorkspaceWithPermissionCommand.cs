using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class UpdateWorkspaceWithPermissionCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<long> PermissionIds { get; set; } = Enumerable.Empty<long>();
    }

    public class UpdateWorkspaceWithPermissionCommandHandler : IRequestHandler<UpdateWorkspaceWithPermissionCommand, bool>
    {
        private readonly IWorkspaceCommandRepository _workspaceCommandRepository;

        public UpdateWorkspaceWithPermissionCommandHandler(IWorkspaceCommandRepository workspaceCommandRepository)
        {
            _workspaceCommandRepository = workspaceCommandRepository;
        }

        public async Task<bool> Handle(UpdateWorkspaceWithPermissionCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceCommandRepository.GetByIdAsync(request.Id, e => e.WorkspacePermissions);
            var workspacePermissions = request.PermissionIds.Select(e => new WorkspacePermission(workspace.Id, e)).ToList();

            if (!workspace.IsSystem)            
                workspace.Update(request.Title, request.Name, request.Description);            
           
            workspace.SetWorkspacePermissions(workspacePermissions);

            _workspaceCommandRepository.Update(workspace);
            var result = await _workspaceCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
