using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Commands
{
    public class CreateBaseInfoCommandValidator : AbstractValidator<CreateBaseInfoCommand>
    {
        public CreateBaseInfoCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateBaseInfoCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.BaseInfoTypeId).NotNull().WithMessage("لطفا نوع اطلاعات پایه را وارد کنید");
            RuleFor(x => x.DisplayValue).NotEmpty().WithMessage("لطفا نام نمایشی را وارد کنید");
            RuleFor(x => x.Value).NotEmpty().WithMessage("لطفا نام را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
