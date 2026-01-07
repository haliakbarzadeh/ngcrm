using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Queries;
using NgCrm.BasicInfoService.Domain.Persons.Services;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Application.Persons.Queries
{
    public class GetPermissionsByPersonIdQueryHandler : IRequestHandler<GetPermissionsByPersonIdQuery, IEnumerable<PersonPermissionDto>>
    {
        private readonly IPersonQueryRepository _personQueryRepository;

        public GetPermissionsByPersonIdQueryHandler(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public async Task<IEnumerable<PersonPermissionDto>> Handle(GetPermissionsByPersonIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _personQueryRepository.GetPersonByIdAsync(request.PersonId, cancellationToken, request.PositionId);

         
            var personPermissionDtos = new List<PersonPermissionDto>();

            if(person != null)
            {
                foreach (var item in person?.PersonPositions)
                {
                    var personPermissionDto = new PersonPermissionDto
                    {
                        WorkspaceId = item.Position.WorkspaceId,
                        PositionPermissionDtos = item.Position.PositionPermissions.Adapt<List<PositionPermissionDto>>().ToList(),
                        PersonPositionPermissionDtos = item.PersonPositionPermissions.Adapt<List<PersonPositionPermissionDto>>().ToList()
                    };

                    personPermissionDtos.Add(personPermissionDto);
                }
            }
           

            return personPermissionDtos;
        }
    }
}
