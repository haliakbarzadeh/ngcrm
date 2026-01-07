using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Users.Contracts;
using NgCrm.BasicInfoService.Domain.Users.Enums;

namespace NgCrm.BasicInfoService.Application.Users.Commands
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        private readonly IUserQueryRepository _userQueryRepository;

        public LoginCommandValidator(IUserQueryRepository userQueryRepository)
        {
            _userQueryRepository = userQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<LoginCommand> context, CancellationToken cancellation = default)
        {
            var user = await _userQueryRepository.GetByExpressionAsync(x => x.Username == context.InstanceToValidate.Username, cancellation);

            RuleFor(x => x).CustomAsync(async (command, context, ct) =>
            {
                if (user == null)
                    context.AddFailure(nameof(LoginCommand.Username), "کاربر موجود نمی باشد");

                

            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
