using Goldiran.Framework.Application.Commands;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Dtos;
using NgCrm.BasicInfoService.Domain.Persons.Entities;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class AddPersonPositionPermissionsCommand : BaseCommandRequest, IRequest<bool>
    {
        public long PersonId { get; set; }
        public long PersonPositionId { get; set; }
        public IEnumerable<PersonPositionPermissionDto> personPositionPermissionDtos { get; set; } = Enumerable.Empty<PersonPositionPermissionDto>();
    }

    public class AddPersonPositionPermissionsCommandHandler : IRequestHandler<AddPersonPositionPermissionsCommand, bool>
    {
        private readonly IPersonCommandRepository _personCommandRepository;

        public AddPersonPositionPermissionsCommandHandler(IPersonCommandRepository personCommandRepository)
        {
            _personCommandRepository = personCommandRepository;
        }

        public async Task<bool> Handle(AddPersonPositionPermissionsCommand request, CancellationToken cancellationToken)
        {
            var person = await _personCommandRepository.GetPersonByIdAsync(request.PersonId, cancellationToken);

            var personPosition = person.PersonPositions.First(e => e.Id == request.PersonPositionId);
            var personPositionPermissions = request.personPositionPermissionDtos
                .Select(e => new PersonPositionPermission(e.PersonPositionId, e.PermissionId, e.IsAllow))
                .ToList();

            personPosition.SetPersonPositionPermission(personPositionPermissions);
            var result = await _personCommandRepository.UnitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
