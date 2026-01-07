using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;

namespace NgCrm.BasicInfoService.Application.Organizations.Commands
{
    public class DeleteOrganizationCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteOrganizationCommandHandler : IRequestHandler<DeleteOrganizationCommand, bool>
    {
        private readonly IOrganizationCommandRepository _organizationCommandRepository;
        private readonly IOrganizationHistoryCommandRepository _organizationHistoryCommandRepository;


        public DeleteOrganizationCommandHandler(IOrganizationCommandRepository organizationCommandRepository,
            IOrganizationHistoryCommandRepository organizationHistoryCommandRepository)
        {
            _organizationCommandRepository = organizationCommandRepository;
            _organizationHistoryCommandRepository = organizationHistoryCommandRepository;
        }

        public async Task<bool> Handle(DeleteOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationCommandRepository.GetByIdAsync(request.Id);
            organization.Archive();

            _organizationCommandRepository.Update(organization);

            await _organizationHistoryCommandRepository.GenerateOrganizationHistory(cancellationToken);

            return (await _organizationCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
        }
    }
}
