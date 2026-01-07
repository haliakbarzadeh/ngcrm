using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Customers
{
    public class CustomerCommandRepository : CommandRepository<Customer, BasicInfoCommandContext>, ICustomerCommandRepository
    {
        public CustomerCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
