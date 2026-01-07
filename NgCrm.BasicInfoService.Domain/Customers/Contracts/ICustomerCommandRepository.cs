using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Entities;

namespace NgCrm.BasicInfoService.Domain.Customers.Contracts
{
    public interface ICustomerCommandRepository : ICommandRepository<Customer>
    {

    }
}
