using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;

namespace NgCrm.BasicInfoService.Domain.Customers.Queries
{
    public class GetCustomerByIdQuery : BaseQueryRequest, IRequest<CustomerDto>
    {
        public long Id { get; set; }
    }

}
