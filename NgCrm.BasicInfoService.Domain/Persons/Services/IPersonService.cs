using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Persons.Services
{
    public interface IPersonService
    {
        Task<PersonDto> BuildPersonDtoAsync(PersonReadModel person, CancellationToken cancellationToken);
    }
}
