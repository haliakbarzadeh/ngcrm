using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.ReadModels;
using NgCrm.BasicInfoService.Domain.Common.Enums;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NgCrm.BasicInfoService.Domain.Customers.Queries
{
    public class GetCustomerQuery : BaseQueryRequest, IRequest<Paged<CustomerDto>>
    {
        [BindNever]
        public bool? IsDeleted { get; set; }=false;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public CustomerTypes? CustomerTypeId { get; set; }
        public bool? IsIranian { get; set; }
        public string? CompanyName { get; set; }
        public string? BrandName { get; set; }
        public string? NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string? Contact { get; set; }
        public VipReasonTypes? VipReasonTypeId { get; set; }

    }
}
