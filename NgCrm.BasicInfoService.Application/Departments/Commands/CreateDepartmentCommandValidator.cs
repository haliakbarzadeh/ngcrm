using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.Departments.Commands
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateDepartmentCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا عنوان فارسی را وارد کنید");
            RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا نام انگلیسی را وارد کنید");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("عنوان فارسی نمی‌تواند بیشتر از 200 کاراکتر باشد");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("نام انگلیسی نمی‌تواند بیشتر از 100 کاراکتر باشد");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}