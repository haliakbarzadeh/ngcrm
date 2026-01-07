using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Commands
{
    public class UpdateBaseInfoCommandValidator : AbstractValidator<UpdateBaseInfoCommand>
    {
        private readonly IBaseInfoQueryRepository _BaseInfoQueryRepository;
        public UpdateBaseInfoCommandValidator(IBaseInfoQueryRepository BaseInfoQueryRepository)
        {
            _BaseInfoQueryRepository = BaseInfoQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateBaseInfoCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            RuleFor(x => x.BaseInfoTypeId).NotNull().WithMessage("لطفا نوع اطلاعات پایه را وارد کنید");
            RuleFor(x => x.DisplayValue).NotEmpty().WithMessage("لطفا نام نمایشی را وارد کنید");
            RuleFor(x => x.Value).NotEmpty().WithMessage("لطفا نام را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
