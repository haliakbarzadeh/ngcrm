using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Application.Persons.Services;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;
using NgCrm.BasicInfoService.Domain.Persons.Services;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPersonByPersonalCodeQueryHandler : IRequestHandler<GetPersonByPersonalCodeQuery, PersonDto>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly IPersonService _personService;

        public GetPersonByPersonalCodeQueryHandler(IPersonQueryRepository personQueryRepository, IPersonService personService)
        {
            _personQueryRepository = personQueryRepository;
            _personService = personService;
        }

        public async Task<PersonDto> Handle(GetPersonByPersonalCodeQuery request, CancellationToken cancellationToken)
        {
            var person = await _personQueryRepository.GetByExpressionAsync(e => e.PersonalCode.Trim() == request.PersonalCode.Trim(), cancellationToken, e => e.PersonAddresses, e => e.PersonContacts, e => e.PersonPositions);

            if (person is null)
                throw new KeyNotFoundException("شخص مورد نظر یافت نشد.");

            var personDto = await _personService.BuildPersonDtoAsync(person, cancellationToken);

            return personDto;
        }
    }
}
