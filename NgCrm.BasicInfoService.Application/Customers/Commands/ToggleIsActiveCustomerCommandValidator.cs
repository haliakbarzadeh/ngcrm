using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class ToggleIsActiveCustomerCommandValidator : AbstractValidator<ToggleIsActiveCustomerCommand>
    {
        public ToggleIsActiveCustomerCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ToggleIsActiveCustomerCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
