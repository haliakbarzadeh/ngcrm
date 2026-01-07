using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class CreateWorkspaceCommandValidator : AbstractValidator<CreateWorkspaceCommand>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        public CreateWorkspaceCommandValidator(IWorkspaceQueryRepository workspaceQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateWorkspaceCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا اسم فارسی را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var isTitleUnique = await _workspaceQueryRepository.IsTitleUniqueAsync(context.InstanceToValidate.Title, cancellation);

                if (!isTitleUnique)
                {
                    context.AddFailure($"لطفا نام تکراری وارد نکنید");
                    return;
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
