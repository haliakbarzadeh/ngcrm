using FluentValidation;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Application.Customers.Commands;

public class CustomerAddressValidator : AbstractValidator<CustomerAddressDto>
{
    public CustomerAddressValidator()
    {
        RuleFor(x => x.Latitude)
            .NotEmpty().WithMessage($"Latitude اجباری است");
        RuleFor(x => x.Longitude)
            .NotEmpty().WithMessage($"Longitude اجباری است");
        RuleFor(x => x.ProvinceId)
            .NotEmpty().WithMessage($"فیلد استان اجباری است");
        RuleFor(x => x.CountyId)
            .NotEmpty().WithMessage($"فیلد شهرستان اجباری است");
    }
}