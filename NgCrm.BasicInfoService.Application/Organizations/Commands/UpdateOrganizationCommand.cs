using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Enums;

namespace NgCrm.BasicInfoService.Application.Organizations.Commands
{
    public class UpdateOrganizationCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public OrganizationTypes organizationTypeId { get; set; }
        public string Name { get; set; }
        public int? Code { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }

    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, bool>
    {
        private readonly IOrganizationCommandRepository _organizationCommandRepository;
        private readonly IOrganizationHistoryCommandRepository _organizationHistoryCommandRepository;


        public UpdateOrganizationCommandHandler(IOrganizationCommandRepository organizationCommandRepository,
            IOrganizationHistoryCommandRepository organizationHistoryCommandRepository)
        {
            _organizationCommandRepository = organizationCommandRepository;
            _organizationHistoryCommandRepository = organizationHistoryCommandRepository;
        }

        public async Task<bool> Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationCommandRepository.GetByIdAsync(request.Id);

            organization.Update(request.Title, request.organizationTypeId, request.Name, request.Code, request.Address, request.IsActive);
            _organizationCommandRepository.Update(organization);
            
            await _organizationHistoryCommandRepository.GenerateOrganizationHistory(cancellationToken);

            return (await _organizationCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
