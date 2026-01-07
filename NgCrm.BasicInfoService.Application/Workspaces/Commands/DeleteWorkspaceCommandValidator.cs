using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class DeleteWorkspaceCommandValidator : AbstractValidator<DeleteWorkspaceCommand>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        private readonly IPositionQueryRepository _positionQueryRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;

        public DeleteWorkspaceCommandValidator(IWorkspaceQueryRepository workspaceQueryRepository,
            IPositionQueryRepository positionQueryRepository,
            IPermissionQueryRepository permissionQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
            _positionQueryRepository = positionQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteWorkspaceCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var workspace = await _workspaceQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation, e => e.WorkspacePermissions);

                if (workspace is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                    return;
                }

                if (workspace.IsSystem)
                {
                    context.AddFailure($"امکان حذف کردن فضای کاری سیستمی وجود ندارد.");
                    return;
                }

                var positions = await _positionQueryRepository.GetAllByWorkspaceIdAsync(context.InstanceToValidate.Id, cancellation);

                if (positions?.Any() == true)
                {
                    var positionNames = String.Join(" - ", positions.Select(e => e.Title).ToList());
                    context.AddFailure($"فضای کاری دارای سمت است. امکان حذف وجود ندارد");
                    return;
                }

                //if (workspace.WorkspacePermissions?.Any() == true)
                //{
                //    var permissionIds = workspace.WorkspacePermissions.Select(e => e.PermissionId).ToList();
                //    var permissions = await _permissionQueryRepository.GetByIdsAsync(permissionIds, cancellation);

                //    var permissionNames = String.Join(" - ", permissions.Select(e => e.Title).ToList());
                //    context.AddFailure($"فضای کاری دارای دسترسی است. امکان حذف وجود ندارد");
                //    return;
                //}
            });


            return await base.ValidateAsync(context, cancellation);
        }
    }
}
