using Mapster;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;
using NgCrm.BasicInfoService.Domain.Persons.Services;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Application.Persons.Services
{
    public class PersonService : IPersonService
    {

        private readonly IPositionQueryRepository _positionQueryRepository;

        public PersonService(IPositionQueryRepository positionQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
        }

        public async Task<PersonDto> BuildPersonDtoAsync(PersonReadModel person, CancellationToken cancellationToken)
        {
            var positionIds = person?.PersonPositions.Select(x => x.PositionId).ToList();
            var positions = await _positionQueryRepository.GetByIdsAsync(positionIds, cancellationToken);

            var personDto = person.Adapt<PersonDto>();

            foreach (var item in personDto.PersonPositions)
                item.PositionDto = positions.First(e => e.Id == item.PositionId).Adapt<PositionDto>();

            return personDto;
        }
    }
}
