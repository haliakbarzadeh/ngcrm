using FluentValidation;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Application.Customers.Commands;

public class CustomerRelationValidator : AbstractValidator<CustomerRelationDto>
{
    public CustomerRelationValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage($"نام اجباری است");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage($"نام خانوادگی اجباری است");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage($"کد ملی اجباری است");
    }
}