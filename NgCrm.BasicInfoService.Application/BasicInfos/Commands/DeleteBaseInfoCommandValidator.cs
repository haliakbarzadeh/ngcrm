using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.BaseInfos.Contracts;

namespace NgCrm.BasicInfoService.Application.BasicInfos.Commands
{
    public class DeleteBaseInfoCommandValidator : AbstractValidator<DeleteBaseInfoCommand>
    {
        private readonly IBaseInfoQueryRepository _BaseInfoQueryRepository;
        public DeleteBaseInfoCommandValidator(IBaseInfoQueryRepository BaseInfoQueryRepository)
        {
            _BaseInfoQueryRepository = BaseInfoQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteBaseInfoCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
