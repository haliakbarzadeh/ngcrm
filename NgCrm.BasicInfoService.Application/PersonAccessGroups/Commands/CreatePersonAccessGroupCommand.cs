using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands
{
    public class CreatePersonAccessGroupCommand : BaseCommandRequest, IRequest<bool>
    {
        public long PersonId { get; set; }
        public long AccessGroupId { get; set; }
    }

    public class CreatePersonAccessGroupCommandHandler : IRequestHandler<CreatePersonAccessGroupCommand, bool>
    {
        private readonly IPersonAccessGroupCommandRepository _personAccessGroupCommandRepository;

        public CreatePersonAccessGroupCommandHandler(IPersonAccessGroupCommandRepository personAccessGroupCommandRepository)
        {
            _personAccessGroupCommandRepository = personAccessGroupCommandRepository;
        }

        public async Task<bool> Handle(CreatePersonAccessGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = new PersonAccessGroup(request.PersonId, request.AccessGroupId);

            _personAccessGroupCommandRepository.Add(entity);

            var result = await _personAccessGroupCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
