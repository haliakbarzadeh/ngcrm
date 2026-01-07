using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Commands
{
    public class DeletePersonDelegateCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeletePersonDelegateCommandHandler : IRequestHandler<DeletePersonDelegateCommand, bool>
    {
        private readonly IPersonDelegateCommandRepository _personDelegateRepository;

        public DeletePersonDelegateCommandHandler(IPersonDelegateCommandRepository personDelegateRepository)
        {
            _personDelegateRepository = personDelegateRepository;
        }

        public async Task<bool> Handle(DeletePersonDelegateCommand request, CancellationToken cancellationToken)
        {
            var personDelegate = await _personDelegateRepository.GetByIdAsync(request.Id);

            personDelegate.Delete();

            _personDelegateRepository.Update(personDelegate);
            var result = await _personDelegateRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}