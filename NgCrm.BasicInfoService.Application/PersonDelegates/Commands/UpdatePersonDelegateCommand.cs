using Goldiran.Framework.Application.Commands;
using Goldiran.Framework.Domain.Services;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Enums;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Commands
{
    public class UpdatePersonDelegateCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public long AssignerPersonId { get; set; }
        public long AssignerPositionId { get; set; }
        public long DelegatePersonId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DelegateReasonTypes ReasonTypeId { get; set; }
        public DelegateStatusTypes StatusTypeId { get; set; }
        public string Description { get; set; }
    }

    public class UpdatePersonDelegateCommandHandler : IRequestHandler<UpdatePersonDelegateCommand, bool>
    {
        private readonly IPersonDelegateCommandRepository _personDelegateRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdatePersonDelegateCommandHandler(IPersonDelegateCommandRepository personDelegateRepository,
            ICurrentUserService currentUserService)
        {
            _personDelegateRepository = personDelegateRepository;
            _currentUserService = currentUserService;
        }

        public async Task<bool> Handle(UpdatePersonDelegateCommand request, CancellationToken cancellationToken)
        {
            var personDelegate = await _personDelegateRepository.GetByIdAsync(request.Id);

            personDelegate.Update(
                request.AssignerPersonId,
                request.AssignerPositionId,
                request.DelegatePersonId,
                request.FromDate,
                request.ToDate,
                request.ReasonTypeId,
                request.StatusTypeId,
                request.Description );

            _personDelegateRepository.Update(personDelegate);
            var result = await _personDelegateRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}