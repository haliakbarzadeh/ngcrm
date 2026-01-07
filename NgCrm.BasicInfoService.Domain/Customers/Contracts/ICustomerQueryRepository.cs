using Goldiran.Framework.Domain.Contracts;
using Goldiran.Framework.Domain.Models;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.Queries;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Queries;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Customers.Contracts
{
    public interface ICustomerQueryRepository : IQueryRepository<CustomerReadModel>
    {
        public Task<Paged<CustomerDto>> GetCustomers(GetCustomerQuery filter, CancellationToken cancellationToken);

    }
}
