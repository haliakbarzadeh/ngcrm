using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class DeletePositionCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand, bool>
    {
        private readonly IPositionCommandRepository _positionCommandRepository;
        private readonly IOrganizationHistoryCommandRepository _organizationHistoryCommandRepository;




        public DeletePositionCommandHandler(IPositionCommandRepository positionCommandRepository,
            IOrganizationHistoryCommandRepository organizationHistoryCommandRepository)
        {
            _positionCommandRepository = positionCommandRepository;
            _organizationHistoryCommandRepository = organizationHistoryCommandRepository;
        }

        public async Task<bool> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionCommandRepository.GetByIdAsync(request.Id);
            position.Archive();

            _positionCommandRepository.Update(position);

            await _organizationHistoryCommandRepository.GenerateOrganizationHistory(cancellationToken);

            return (await _positionCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
