using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class SetPermissionsToWorkspaceCommandValidator : AbstractValidator<SetPermissionsToWorkspaceCommand>
    {
        private readonly IPermissionQueryRepository _permissionQueryRepository;

        public SetPermissionsToWorkspaceCommandValidator(IPermissionQueryRepository permissionQueryRepository)
        {
            _permissionQueryRepository = permissionQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<SetPermissionsToWorkspaceCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.WorkspaceId).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                if (context.InstanceToValidate.PermissionIds.Where(e => e != 0).Count() > 0)
                {
                    var ids = context.InstanceToValidate.PermissionIds.Where(e => e != 0).Distinct().ToList();

                    var permissions = await _permissionQueryRepository.GetByIdsAsync(ids, cancellation);

                    if (permissions.Count() != ids.Count())
                    {
                        context.AddFailure($"دسترسی های ارسالی اشتباه است");
                    }
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
