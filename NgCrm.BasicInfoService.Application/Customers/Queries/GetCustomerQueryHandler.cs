using Goldiran.Framework.Domain.Models;
using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Queries;

namespace NgCrm.BasicInfoService.Application.Customers.Queries
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, Paged<CustomerDto>>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<Paged<CustomerDto>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var list = await _customerQueryRepository.GetCustomers(request,cancellationToken);
            return list;
        }
    }
}
