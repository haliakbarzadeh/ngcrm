using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Workspaces.Contracts;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class UpdatePositionCommandValidator : AbstractValidator<UpdatePositionCommand>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;
        private readonly IWorkspaceQueryRepository _workspaceQueryRepository;
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public UpdatePositionCommandValidator(IPositionQueryRepository positionQueryRepository,
            IWorkspaceQueryRepository workspaceQueryRepository,
            IOrganizationQueryRepository organizationQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
            _workspaceQueryRepository = workspaceQueryRepository;
            _organizationQueryRepository = organizationQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdatePositionCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");
            //RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا نام را وارد کنید");
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا عنوان را وارد کنید");
            RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("لطفا شناسه ساختار سازمانی را وارد کنید");
            RuleFor(x => x.WorkspaceId).NotEmpty().WithMessage("لطفا فضای کاری را وارد کنید");
            RuleFor(x => x.PositionTypeId).NotEmpty().WithMessage("لطفا نوع را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var position = await _positionQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation);

                if (position is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                    return;
                }

                var workspace = await _workspaceQueryRepository.GetByIdAsync(context.InstanceToValidate.WorkspaceId, cancellation);

                if (workspace is null)
                {
                    context.AddFailure($"با شناسه ارسالی فضای کاری تعریف نشده");
                    return;
                }

                var organization = await _organizationQueryRepository.GetByIdAsync(context.InstanceToValidate.OrganizationId, cancellation);

                if (organization is null)
                {
                    context.AddFailure($" شناسه ارسالی در ساختار ساززمانی تعریف نشده");
                    return;
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
