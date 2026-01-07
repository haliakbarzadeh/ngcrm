using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Entities;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;

namespace NgCrm.BasicInfoService.Application.Organizations.Commands
{
    public class CreateOrganizationCommand : BaseCommandRequest, IRequest<bool>
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public long? ParentId { get; set; }
        public OrganizationTypes OrganizationTypeId { get; set; }
        public int? Code { get; set; } = null;
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }

    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, bool>
    {
        private readonly IOrganizationCommandRepository _organizationCommandRepository;
        private readonly IOrganizationHistoryCommandRepository _organizationHistoryCommandRepository;

        public CreateOrganizationCommandHandler(IOrganizationCommandRepository organizationCommandRepository, IOrganizationHistoryCommandRepository organizationHistoryCommandRepository)
        {
            _organizationCommandRepository = organizationCommandRepository;
            _organizationHistoryCommandRepository = organizationHistoryCommandRepository;
        }

        public async Task<bool> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Organization(request.Title, request.Name, request.ParentId, request.OrganizationTypeId, request.Code, request.Address, request.IsActive);
            
            _organizationCommandRepository.Add(entity);
            await _organizationHistoryCommandRepository.GenerateOrganizationHistory(cancellationToken);

            return (await _organizationCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
