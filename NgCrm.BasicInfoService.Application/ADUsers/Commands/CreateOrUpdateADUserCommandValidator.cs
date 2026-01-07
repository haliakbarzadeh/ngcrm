using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.ADUsers.Commands
{
    public class CreateOrUpdateADUserCommandValidator : AbstractValidator<CreateOrUpdateADUserCommand>
    {
        public CreateOrUpdateADUserCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateOrUpdateADUserCommand> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}
