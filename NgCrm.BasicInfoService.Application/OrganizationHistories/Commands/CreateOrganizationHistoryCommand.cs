using Goldiran.Framework.Application.Commands;
using MediatR;
using Newtonsoft.Json;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Entities;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;

namespace NgCrm.BasicInfoService.Application.OrganizationHistories.Commands
{
    public class CreateOrganizationHistoryCommand : BaseCommandRequest, IRequest<bool>
    {
    }

    public class CreateOrganizationHistoryCommandHandler : IRequestHandler<CreateOrganizationHistoryCommand, bool>
    {
        private readonly IOrganizationHistoryCommandRepository _organizationHistoryCommandRepository;
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public CreateOrganizationHistoryCommandHandler(IOrganizationHistoryCommandRepository organizationHistoryCommandRepository,
            IOrganizationQueryRepository organizationQueryRepository)
        {
            _organizationHistoryCommandRepository = organizationHistoryCommandRepository;
            _organizationQueryRepository = organizationQueryRepository;
        }

        public async Task<bool> Handle(CreateOrganizationHistoryCommand request, CancellationToken cancellationToken)
        {
            var organizations = await _organizationQueryRepository.GetAllAsync(cancellationToken, e => e.Positions);

            if (organizations is null)
                return true;

            var json = JsonConvert.SerializeObject(organizations, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            var entity = new OrganizationHistory(json, DateTime.Now);
            _organizationHistoryCommandRepository.Add(entity);

            var result = await _organizationHistoryCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
