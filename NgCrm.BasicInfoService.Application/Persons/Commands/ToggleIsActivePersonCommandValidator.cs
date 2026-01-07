using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class ToggleIsActivePersonCommandValidator : AbstractValidator<ToggleIsActivePersonCommand>
    {
        public ToggleIsActivePersonCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ToggleIsActivePersonCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
