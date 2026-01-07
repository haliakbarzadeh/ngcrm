using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class ToggleIsActivePersonCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class ToggleIsActivePersonCommandHandler : IRequestHandler<ToggleIsActivePersonCommand, bool>
    {
        private readonly IPersonCommandRepository _personCommandRepository;


        public ToggleIsActivePersonCommandHandler(IPersonCommandRepository personCommandRepository)
        {
            _personCommandRepository = personCommandRepository;
        }

        public async Task<bool> Handle(ToggleIsActivePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personCommandRepository.GetByIdAsync(request.Id);

            person.ToggleIsActive();

            _personCommandRepository.Update(person);

            var result = await _personCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
