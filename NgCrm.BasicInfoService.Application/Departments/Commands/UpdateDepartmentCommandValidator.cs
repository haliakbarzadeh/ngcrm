using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;

namespace NgCrm.BasicInfoService.Application.Departments.Commands
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;

        public UpdateDepartmentCommandValidator(IDepartmentQueryRepository departmentQueryRepository)
        {
            _departmentQueryRepository = departmentQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateDepartmentCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه بخش را وارد کنید");
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا عنوان فارسی را وارد کنید");
            RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا نام انگلیسی را وارد کنید");
            RuleFor(x => x.Title).MaximumLength(200).WithMessage("عنوان فارسی نمی‌تواند بیشتر از 200 کاراکتر باشد");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("نام انگلیسی نمی‌تواند بیشتر از 100 کاراکتر باشد");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("توضیحات نمی‌تواند بیشتر از 500 کاراکتر باشد");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var department = await _departmentQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation);

                if (department is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                    return;
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}