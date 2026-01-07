using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.Permissions.Commands
{
    public class CreatePermissionCommandValidator : AbstractValidator<CreatePermissionCommand>
    {
        public CreatePermissionCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreatePermissionCommand> context, CancellationToken cancellation = default)
        {
            //var exisitngRole = await _roleQueryRepository.AnyAsync(x => x.Title == context.InstanceToValidate.Title, cancellation);

            //RuleFor(x => x).Must(x => exisitngRole).WithMessage("NOT OK");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
