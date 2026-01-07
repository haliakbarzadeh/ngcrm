using Mapster;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Queries;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Application.Customers.Queries
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;

        public GetCustomerByIdQueryHandler(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var Customer = await _customerQueryRepository.GetByIdAsync(
                request.Id,
                cancellationToken,
                e => e.CustomerAddresses,
                e => e.CustomerContacts,
                e => e.CustomerRelations,
                e => e.Nationality,
                e => e.CustomerTitle);

            if (Customer is null)
                throw new KeyNotFoundException("شخص مورد نظر یافت نشد.");

            var CustomerDto = Customer.Adapt<CustomerDto>();

            return CustomerDto;
        }
    }
}
