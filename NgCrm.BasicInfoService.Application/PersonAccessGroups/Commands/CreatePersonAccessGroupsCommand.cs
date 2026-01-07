using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands
{
    public class CreatePersonAccessGroupsCommand : BaseCommandRequest, IRequest<bool>
    {
        public long PersonId { get; set; }
        public IEnumerable<long> AccessGroupIds { get; set; }
    }

    public class CreatePersonAccessGroupsCommandHandler : IRequestHandler<CreatePersonAccessGroupsCommand, bool>
    {
        private readonly IPersonAccessGroupCommandRepository _personAccessGroupCommandRepository;

        public CreatePersonAccessGroupsCommandHandler(IPersonAccessGroupCommandRepository personAccessGroupCommandRepository)
        {
            _personAccessGroupCommandRepository = personAccessGroupCommandRepository;
        }

        public async Task<bool> Handle(CreatePersonAccessGroupsCommand request, CancellationToken cancellationToken)
        {
            var list = request.AccessGroupIds.Select(e => new PersonAccessGroup(request.PersonId, e)).ToList();

            _personAccessGroupCommandRepository.AddRange(list);

            var result = await _personAccessGroupCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
