using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class CreateWorkspaceWithPermissionCommandValidator : AbstractValidator<CreateWorkspaceWithPermissionCommand>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        public CreateWorkspaceWithPermissionCommandValidator(IWorkspaceQueryRepository workspaceQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateWorkspaceWithPermissionCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا اسم فارسی را وارد کنید");
            //RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا اسم انگلیسی را وارد کنید");
            RuleFor(x => x.PermissionIds.Any()).NotEqual(false).WithMessage("بدون دسترسی ارسال شده است");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var isTitleUnique = await _workspaceQueryRepository.IsTitleUniqueAsync(context.InstanceToValidate.Title, cancellation);

                if (!isTitleUnique)
                {
                    context.AddFailure($"فضای کاری با این عنوان قبلا ثبت شده است.");
                    return;
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
