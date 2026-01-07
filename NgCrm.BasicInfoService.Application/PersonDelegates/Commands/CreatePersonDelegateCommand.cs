using Goldiran.Framework.Application.Commands;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Entities;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Commands
{
    public class CreatePersonDelegateCommand : BaseCommandRequest, IRequest<long>
    {
        public long AssignerPersonId { get; set; }
        public long AssignerPositionId { get; set; }
        public long DelegatePersonId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DelegateReasonTypes ReasonTypeId { get; set; }
        public string Description { get; set; }
    }

    public class CreatePersonDelegateCommandHandler : IRequestHandler<CreatePersonDelegateCommand, long>
    {
        private readonly IPersonDelegateCommandRepository _personDelegateRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreatePersonDelegateCommandHandler(IPersonDelegateCommandRepository personDelegateRepository, ICurrentUserService currentUserService)
        {
            _personDelegateRepository = personDelegateRepository;
            _currentUserService = currentUserService;
        }

        public async Task<long> Handle(CreatePersonDelegateCommand request, CancellationToken cancellationToken)
        {
            var personDelegate = new PersonDelegate(
                request.AssignerPersonId,
                request.AssignerPositionId,
                request.DelegatePersonId,
                request.FromDate,
                request.ToDate,
                request.ReasonTypeId,
                request.Description,
                (long)_currentUserService.PersonId);

            _personDelegateRepository.Add(personDelegate);
            var result = await _personDelegateRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0 ? personDelegate.Id : 0;
        }
    }
}