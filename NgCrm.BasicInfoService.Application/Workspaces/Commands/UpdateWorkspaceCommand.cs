using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class UpdateWorkspaceCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateWorkspaceCommandHandler : IRequestHandler<UpdateWorkspaceCommand, bool>
    {
        private readonly IWorkspaceCommandRepository _workspaceCommandRepository;

        public UpdateWorkspaceCommandHandler(IWorkspaceCommandRepository workspaceCommandRepository)
        {
            _workspaceCommandRepository = workspaceCommandRepository;
        }

        public async Task<bool> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceCommandRepository.GetByIdAsync(request.Id);

            workspace.Update(request.Title, request.Name, request.Description);

            _workspaceCommandRepository.Update(workspace);
            var result = await _workspaceCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
