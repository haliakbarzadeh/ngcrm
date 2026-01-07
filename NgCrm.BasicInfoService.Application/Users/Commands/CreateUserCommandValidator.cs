using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Application.Users.Commands
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateUserCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.PersonId).NotEmpty().WithMessage("لطفا شخص مورد نظر را وارد کنید");
            RuleFor(x => x.AccountTypeId).NotEmpty().WithMessage("لطفا نوع حساب کاربری را وارد کنید");
            RuleFor(x => x.IsActive).NotNull().WithMessage("لطفا وضعیت را وارد کنید");


            if(context.InstanceToValidate.AccountTypeId == AccountTypes.ActiveDirectory)
            {
                RuleFor(x => x.ADUserId).NotEmpty().WithMessage("لطفا کاربر مورد نظر را انتخاب کنید");
            }

            if (context.InstanceToValidate.AccountTypeId == AccountTypes.Local)
            {
                RuleFor(x => x.Username).NotEmpty().WithMessage("لطفا نام کاربری مورد نظر را وارد کنید");
                RuleFor(x => x.Password).NotEmpty().WithMessage("لطفا رمز مورد نظر را وارد کنید");
            }

            if (!Enum.IsDefined(typeof(AccountTypes), context.InstanceToValidate.AccountTypeId))
                context.AddFailure("نوع کاربر اشتباه است");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
