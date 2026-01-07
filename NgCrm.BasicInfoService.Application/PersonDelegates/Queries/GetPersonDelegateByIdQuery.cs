using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Contracts;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Dtos;
using NgCrm.BasicInfoService.Domain.PersonDelegates.Queries;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Queries
{

    public class GetPersonDelegateByIdQueryHandler : IRequestHandler<GetPersonDelegateByIdQuery, PersonDelegateDto>
    {
        private readonly IPersonDelegateQueryRepository _personDelegateRepository;

        public GetPersonDelegateByIdQueryHandler(IPersonDelegateQueryRepository personDelegateRepository)
        {
            _personDelegateRepository = personDelegateRepository;
        }

        public async Task<PersonDelegateDto> Handle(GetPersonDelegateByIdQuery request, CancellationToken cancellationToken)
        {
            var personDelegate = await _personDelegateRepository.GetByIdAsync(request.Id, cancellationToken,e=>e.AssignerPosition, e => e.DelegatePerson, e => e.AssignerPerson);
            return personDelegate.Adapt<PersonDelegateDto>();
        }
    }
}