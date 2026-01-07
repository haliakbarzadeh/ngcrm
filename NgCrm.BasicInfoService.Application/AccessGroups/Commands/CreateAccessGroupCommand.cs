using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.AccessGroups.Entities;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Commands
{
    public class CreateAccessGroupCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }

        public IEnumerable<long> PersonIds { get; set; }
    }

    public class CreateAccessGroupCommandHandler : IRequestHandler<CreateAccessGroupCommand, bool>
    {
        private readonly IAccessGroupCommandRepository _accessGroupCommandRepository;
        private readonly IPersonAccessGroupCommandRepository _personAccessGroupCommandRepository;

        public CreateAccessGroupCommandHandler(IAccessGroupCommandRepository accessGroupCommandRepository,
            IPersonAccessGroupCommandRepository personAccessGroupCommandRepository)
        {
            _accessGroupCommandRepository = accessGroupCommandRepository;
            _personAccessGroupCommandRepository = personAccessGroupCommandRepository;
        }

        public async Task<bool> Handle(CreateAccessGroupCommand request, CancellationToken cancellationToken)
        {
            var accessGroup = new AccessGroup(request.Title, request.Name, request.IsActive,request.Description);
            _accessGroupCommandRepository.Add(accessGroup);

            if (request.PersonIds.Count()> 0)
            {
                var personAccessGroups = request.PersonIds.Select(e => new PersonAccessGroup(e, accessGroup)).ToList();
                _personAccessGroupCommandRepository.AddRange(personAccessGroups);               
            }

            var result = await _accessGroupCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
