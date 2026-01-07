using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Application.Persons.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Application.Locations.Commands
{
    public class CreateOrUpdateLocationCommandValidator : AbstractValidator<CreateOrUpdateLocationCommand>
    {
        public CreateOrUpdateLocationCommandValidator()
        {
                
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateOrUpdateLocationCommand> context, CancellationToken cancellation = default)
        {
         
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا نام را وارد کنید");
         
            return await base.ValidateAsync(context, cancellation);
        }

    }
}
