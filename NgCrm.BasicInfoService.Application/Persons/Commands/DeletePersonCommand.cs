using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class DeletePersonCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly IPersonCommandRepository _personCommandRepository;

        public DeletePersonCommandHandler(IPersonCommandRepository personCommandRepository)
        {
            _personCommandRepository = personCommandRepository;
        }

        public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var person = await _personCommandRepository.GetByIdAsync(request.Id);

            person.Archive();


            _personCommandRepository.Update(person);
            var result = await _personCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return 1 > 0;
        }
    }
}
