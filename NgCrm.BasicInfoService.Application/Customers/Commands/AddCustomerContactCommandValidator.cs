using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Common.Utils;
using NgCrm.BasicInfoService.Domain.Customers.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class AddCustomerContactCommandValidator : AbstractValidator<AddCustomerContactCommand>
    {
        public AddCustomerContactCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddCustomerContactCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.CustomerContact)
            .SetValidator(x => new CustomerContactValidator());

            return await base.ValidateAsync(context, cancellation);
        }

      
    }
}
