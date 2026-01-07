using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Commands
{
    public class DeleteAccessGroupCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteAccessGroupCommandHandler : IRequestHandler<DeleteAccessGroupCommand, bool>
    {
        private readonly IAccessGroupCommandRepository _accessGroupCommandRepository;

        public DeleteAccessGroupCommandHandler(IAccessGroupCommandRepository accessGroupCommandRepository)
        {
            _accessGroupCommandRepository = accessGroupCommandRepository;
        }

        public async Task<bool> Handle(DeleteAccessGroupCommand request, CancellationToken cancellationToken)
        {
            var accessGroup = await _accessGroupCommandRepository.GetByIdAsync(request.Id);

            accessGroup.Archive();
            _accessGroupCommandRepository.Update(accessGroup);          

            var result = await _accessGroupCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
