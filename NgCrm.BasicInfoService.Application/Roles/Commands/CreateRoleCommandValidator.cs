using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Roles.Contracts;

namespace NgCrm.BasicInfoService.Application.Roles.Commands
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        private readonly IRoleQueryRepository _roleQueryRepository;

        public CreateRoleCommandValidator(IRoleQueryRepository roleQueryRepository)
        {
            _roleQueryRepository = roleQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateRoleCommand> context, CancellationToken cancellation = default)
        {
            var exisitngRole = await _roleQueryRepository.AnyAsync(x => x.Title == context.InstanceToValidate.Title, cancellation);

            //RuleFor(x => x).CustomAsync(async (command, context, ct) =>
            //{
            //    if (true)
            //    {
            //        context.AddFailure("Email33333333333333333 is already taken.");
            //    }
            //});


            // RuleFor(x => x).Must(x => exisitngRole).WithMessage("NOT OK");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
