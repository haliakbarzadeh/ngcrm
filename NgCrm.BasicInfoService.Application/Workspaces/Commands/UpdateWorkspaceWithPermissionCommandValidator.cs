using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Workspaces.Commands
{
    public class UpdateWorkspaceWithPermissionCommandValidator : AbstractValidator<UpdateWorkspaceWithPermissionCommand>
    {
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;

        public UpdateWorkspaceWithPermissionCommandValidator(IWorkspaceQueryRepository workspaceQueryRepository)
        {
            _workspaceQueryRepository = workspaceQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateWorkspaceWithPermissionCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا اسم فارسی را وارد کنید");
            //RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا اسم انگلیسی را وارد کنید");
            RuleFor(x => x.PermissionIds.Any()).NotEqual(false).WithMessage("بدون دسترسی ارسال شده است");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var workpace = await _workspaceQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation);

                if (workpace is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                }

                //if (workpace.IsSystem)
                //{
                //    context.AddFailure($"امکان ویرایش فضای کاری سیستمی وجود ندارد.");
                //}

                if (!workpace.IsSystem)
                {
                    var isTitleUnique = await _workspaceQueryRepository.IsTitleUniqueAsync(context.InstanceToValidate.Title, cancellation, context.InstanceToValidate.Id);

                    if (!isTitleUnique)
                    {
                        context.AddFailure($"فضای کاری با این عنوان قبلا ثبت شده است.");
                    }
                }

                
            });


            return await base.ValidateAsync(context, cancellation);
        }
    }
}
