using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Organizations.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Organizations
{
    public class OrganizationCommandRepository : CommandRepository<Organization, BasicInfoCommandContext>, IOrganizationCommandRepository
    {
        public OrganizationCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
