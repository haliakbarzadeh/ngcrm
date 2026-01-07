using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Entities;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Commands
{
    public class UpdateAccessGroupCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public string Description { get; set; }

        public IEnumerable<long> PersonIds { get; set; }
    }

    public class UpdateAccessGroupCommandHandler : IRequestHandler<UpdateAccessGroupCommand, bool>
    {
        private readonly IAccessGroupCommandRepository _accessGroupCommandRepository;
        private readonly IPersonAccessGroupCommandRepository _personAccessGroupCommandRepository;

        public UpdateAccessGroupCommandHandler(IAccessGroupCommandRepository accessGroupCommandRepository, 
            IPersonAccessGroupCommandRepository personAccessGroupCommandRepository)
        {
            _accessGroupCommandRepository = accessGroupCommandRepository;
            _personAccessGroupCommandRepository = personAccessGroupCommandRepository;
        }

        public async Task<bool> Handle(UpdateAccessGroupCommand request, CancellationToken cancellationToken)
        {
            request.PersonIds = request.PersonIds.Distinct();

            var accessGroup = await _accessGroupCommandRepository.GetByIdAsync(request.Id);

            accessGroup.Update(request.Title, request.Name, request.IsActive, request.Description);
            _accessGroupCommandRepository.Update(accessGroup);

            var personAccessGroups = await _personAccessGroupCommandRepository.GetByAccessGroupIdAsync(request.Id, cancellationToken);

            var listAdd = request.PersonIds
                .Where(personId => !personAccessGroups.Any(e => e.PersonId == personId))
                .Select(personId => new PersonAccessGroup(personId, request.Id))
                .ToList();

            var listDelete = personAccessGroups
                .Where(e => !request.PersonIds.Any(personId => personId == e.PersonId))
                .ToList();

            foreach (var item in listDelete)
            {
                item.Archive();
                _personAccessGroupCommandRepository.Update(item);
            }

            _personAccessGroupCommandRepository.AddRange(listAdd);

            var result = await _accessGroupCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
