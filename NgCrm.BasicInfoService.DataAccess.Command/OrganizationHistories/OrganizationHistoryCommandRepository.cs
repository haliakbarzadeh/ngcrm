using Goldiran.Framework.EFCore.Repositories;
using Newtonsoft.Json;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Contracts;
using NgCrm.BasicInfoService.Domain.OrganizationHistories.Entities;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;

namespace NgCrm.BasicInfoService.DataAccess.Command.OrganizationHistories
{
    public class OrganizationHistoryCommandRepository : CommandRepository<OrganizationHistory, BasicInfoCommandContext>, IOrganizationHistoryCommandRepository
    {
        private readonly IOrganizationQueryRepository _organizationQueryRepository;
        public OrganizationHistoryCommandRepository(IOrganizationQueryRepository organizationQueryRepository, BasicInfoCommandContext dbContext) : base(dbContext)
        {
            _organizationQueryRepository = organizationQueryRepository;
        }

        public async Task GenerateOrganizationHistory(CancellationToken cancellationToken)
        {
            var organizations = await _organizationQueryRepository.GetAllAsync(cancellationToken, e => e.Positions);

            if (organizations is not null)
            {
                var json = JsonConvert.SerializeObject(organizations, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                var entity = new OrganizationHistory(json, DateTime.Now);
                EntitySet.Add(entity);
            }
        }
    }
}
