using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Entities;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class CreateWorkspaceCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool IsSystem { get; set; }

    }

    public class CreateWorkspaceCommandHandler : IRequestHandler<CreateWorkspaceCommand, bool>
    {
        private readonly IWorkspaceCommandRepository _workspaceCommandRepository;

        public CreateWorkspaceCommandHandler(IWorkspaceCommandRepository workspaceCommandRepository)
        {
            _workspaceCommandRepository = workspaceCommandRepository;
        }

        public async Task<bool> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {
            var entity = new Workspace(request.Title, request.Name, request.Description);

            _workspaceCommandRepository.Add(entity);
            var result = await _workspaceCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
