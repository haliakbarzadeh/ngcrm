using FluentValidation;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Application.Customers.Commands;

public class CustomerContactValidator : AbstractValidator<CustomerContactDto>
{
    public CustomerContactValidator()
    {
        RuleFor(x => x.Contact)
            .NotEmpty().WithMessage($"اطلاعات تماس اجباری است");
    }
}