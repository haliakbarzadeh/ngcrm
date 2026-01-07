using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;

namespace NgCrm.BasicInfoService.Application.Organizations.Commands
{
    public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
    {
        private readonly IOrganizationQueryRepository _organizationQueryRepository;

        public UpdateOrganizationCommandValidator(IOrganizationQueryRepository organizationQueryRepository)
        {
            _organizationQueryRepository = organizationQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateOrganizationCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه ساختار سازمانی را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var organization = await _organizationQueryRepository.GetByIdAsync(model.Id, cancellation);

                if (organization is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                    return;
                }

                if(organization.ParentId != null)
                {
                    var organizations = await _organizationQueryRepository.GetAllByParentIdAsync((long)organization.ParentId, cancellation);

                    var hasValue = organizations
                    .Where(e => e.Id != model.Id)
                    .Any(e => e.Title == model.Title);

                    if (hasValue)
                    {
                        context.AddFailure($"لطفا نام تکراری وارد نکنید");
                    }
                }
                else
                {
                    if (!model.IsActive)
                    {
                        context.AddFailure($"واحد سازمانی مدیریت نمیتواند غیر فعال شود");
                    }
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
