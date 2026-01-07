using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;

namespace NgCrm.BasicInfoService.Application.Organizations.Commands
{
    public class DeleteOrganizationCommandValidator : AbstractValidator<DeleteOrganizationCommand>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public DeleteOrganizationCommandValidator(IPositionQueryRepository positionQueryRepository, IOrganizationQueryRepository organizationQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
            _organizationQueryRepository = organizationQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteOrganizationCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه ساختار سازمانی را وارد کنید"); ;

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var hasValue = await _organizationQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation);

                if (hasValue is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                }

                if (hasValue.ParentId is null)
                {
                    context.AddFailure($"امکان حذف واحد سازمانی مدیریت وجود ندارد ");
                    return;
                }

                var positions = await _positionQueryRepository.GetAllByOrganizationIdAsync(context.InstanceToValidate.Id, cancellation);

                if (positions?.Any() == true)
                {
                    var positionNames = String.Join(" - ", positions.Select(e => e.Title).ToList());
                    context.AddFailure($"در این واحد سازمانی سمت (های) {positionNames} تخصیص داده شده است . امکان حذف وجود ندارد");
                }

                var children = await _organizationQueryRepository.GetAllByParentIdAsync(context.InstanceToValidate.Id, cancellation);
             
                if (children?.Any() == true)
                {
                    var childrenNames = String.Join(" - ", children.Select(e => e.Title).ToList());
                    context.AddFailure($"امکان حذف وجود ندارد، نام زیرگروه مرتبط با درخواست ارسالی : {childrenNames}");
                }
            });


            return await base.ValidateAsync(context, cancellation);
        }
    }
}
