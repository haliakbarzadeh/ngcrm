using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Common.Utils;
using NgCrm.BasicInfoService.Domain.Customers.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class AddCustomerRelationCommandValidator : AbstractValidator<AddCustomerRelationCommand>
    {
        public AddCustomerRelationCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddCustomerRelationCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.CustomerRelation)
            .SetValidator(x => new CustomerRelationValidator());

            return await base.ValidateAsync(context, cancellation);
        }

      
    }
}
