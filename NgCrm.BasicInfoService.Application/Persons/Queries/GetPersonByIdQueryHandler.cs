using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;
using NgCrm.BasicInfoService.Domain.Persons.Services;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly IPersonService _personService;

        public GetPersonByIdQueryHandler(IPersonQueryRepository personQueryRepository, IPersonService personService)
        {
            _personQueryRepository = personQueryRepository;
            _personService = personService;
        }

        public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _personQueryRepository.GetByIdAsync(
                request.Id,
                cancellationToken,
                e => e.PersonAddresses,
                e => e.PersonContacts,
                e => e.PersonPositions);

            if (person is null)
                throw new KeyNotFoundException("شخص مورد نظر یافت نشد.");

            var personDto = await _personService.BuildPersonDtoAsync(person, cancellationToken);

            return personDto;
        }
    }
}
