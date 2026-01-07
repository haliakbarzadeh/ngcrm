using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.OrganizationHistories.Commands
{
    public class CreateOrganizationHistoryCommandValidator : AbstractValidator<CreateOrganizationHistoryCommand>
    {
        public CreateOrganizationHistoryCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateOrganizationHistoryCommand> context, CancellationToken cancellation = default)
        {
            return await base.ValidateAsync(context, cancellation);
        }
    }
}
