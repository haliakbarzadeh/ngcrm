using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Common.Utils;
using NgCrm.BasicInfoService.Domain.Customers.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class AddCustomerAddressCommandValidator : AbstractValidator<AddCustomerAddressCommand>
    {
        public AddCustomerAddressCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddCustomerAddressCommand> context, CancellationToken cancellation = default)
        {

            RuleFor(x => x.CustomerAddress)
                .SetValidator(x => new CustomerAddressValidator());

            return await base.ValidateAsync(context, cancellation);
        }

      
    }
}
