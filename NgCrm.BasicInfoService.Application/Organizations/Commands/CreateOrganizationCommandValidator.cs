using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Organizations.Contracts;

namespace NgCrm.BasicInfoService.Application.Organizations.Commands
{
    public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
    {
        private readonly IOrganizationQueryRepository _organizationQueryRepository;
        public CreateOrganizationCommandValidator(IOrganizationQueryRepository organizationQueryRepository)
        {
            _organizationQueryRepository = organizationQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateOrganizationCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا نام سازمانی را وارد کنید");
            //RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا نام انگلیسی سازمانی را وارد کنید"); 
            RuleFor(x => x.OrganizationTypeId).NotEmpty().WithMessage("لطفا نوع را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var isEmpty = !await _organizationQueryRepository.AnyAsync(_ => true, cancellation);

                var noParentId = model.ParentId is null || model.ParentId == 0;

                if (isEmpty)
                {
                    if (!noParentId)
                        context.AddFailure($"لطفا سر شاخه رو ارسال نکنید ");

                    if (!model.IsActive)
                        context.AddFailure($"نمیتواند فعال نباشد ");
                }
                else 
                {
                    if (noParentId)
                        context.AddFailure($"لطفا سر شاخه رو تعیین کنید ");
                    else
                    {
                        var organizations = await _organizationQueryRepository.GetAllByParentIdAsync((long)model.ParentId, cancellation);

                        var hasValue = organizations.Any(e => e.Title == model.Title);

                        if (hasValue)
                        {
                            context.AddFailure($"لطفا نام تکراری وارد نکنید");
                        }
                    }
                }
                

            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
