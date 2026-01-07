using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class ToggleIsActivePositionCommandValidator : AbstractValidator<ToggleIsActivePositionCommand>
    {
        public ToggleIsActivePositionCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<ToggleIsActivePositionCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
