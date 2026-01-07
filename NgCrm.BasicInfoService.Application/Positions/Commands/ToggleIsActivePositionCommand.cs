using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class ToggleIsActivePositionCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class ToggleIsActivePositionCommandHandler : IRequestHandler<ToggleIsActivePositionCommand, bool>
    {
        private readonly IPositionCommandRepository _positionCommandRepository;


        public ToggleIsActivePositionCommandHandler(IPositionCommandRepository positionCommandRepository)
        {
            _positionCommandRepository = positionCommandRepository;
        }

        public async Task<bool> Handle(ToggleIsActivePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _positionCommandRepository.GetByIdAsync(request.Id);

            position.ToggleIsActive();

            _positionCommandRepository.Update(position);

            var result = await _positionCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
