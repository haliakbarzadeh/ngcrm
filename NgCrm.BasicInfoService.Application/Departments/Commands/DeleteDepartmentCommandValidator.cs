using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Departments.Contracts;

namespace NgCrm.BasicInfoService.Application.Departments.Commands
{
    public class DeleteDepartmentCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        private readonly IDepartmentQueryRepository _departmentQueryRepository;

        public DeleteDepartmentCommandValidator(IDepartmentQueryRepository departmentQueryRepository)
        {
            _departmentQueryRepository = departmentQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteDepartmentCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var department = await _departmentQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation);

                if (department is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                    return;
                }

                var childDepartments = await _departmentQueryRepository.GetAllByParentIdAsync(context.InstanceToValidate.Id, cancellation);

                if (childDepartments?.Any() == true)
                {
                    var childNames = String.Join(" - ", childDepartments.Select(e => e.Title).ToList());
                    context.AddFailure($"امکان حذف وجود ندارد، نام بخش‌های فرعی مرتبط: {childNames}");
                    return;
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}