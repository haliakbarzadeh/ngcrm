using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands
{
    public class CreateAccessGroupPersonsCommand : BaseCommandRequest, IRequest<bool>
    {
        public long AccessGroupId { get; set; }
        public IEnumerable<long> PersonIds { get; set; }
    }

    public class CreateAccessGroupPersonsCommandHandler : IRequestHandler<CreateAccessGroupPersonsCommand, bool>
    {
        private readonly IPersonAccessGroupCommandRepository _personAccessGroupCommandRepository;

        public CreateAccessGroupPersonsCommandHandler(IPersonAccessGroupCommandRepository personAccessGroupCommandRepository)
        {
            _personAccessGroupCommandRepository = personAccessGroupCommandRepository;
        }

        public async Task<bool> Handle(CreateAccessGroupPersonsCommand request, CancellationToken cancellationToken)
        {
            var list = request.PersonIds.Select(e => new PersonAccessGroup(e, request.AccessGroupId)).ToList();

            _personAccessGroupCommandRepository.AddRange(list);

            var result = await _personAccessGroupCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
