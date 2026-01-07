using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands
{
    public class CreatePersonAccessGroupCommandValidator : AbstractValidator<CreatePersonAccessGroupCommand>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly IAccessGroupQueryRepository _accessGroupQueryRepository;

        public CreatePersonAccessGroupCommandValidator(IPersonQueryRepository personQueryRepository, IAccessGroupQueryRepository accessGroupQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
            _accessGroupQueryRepository = accessGroupQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreatePersonAccessGroupCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.PersonId).NotEmpty().WithMessage("لطفا شناسه کاربر را وارد کنید");
            RuleFor(x => x.AccessGroupId).NotEmpty().WithMessage("لطفا گروه دسترسی را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var hasPerson = await _personQueryRepository.AnyAsync(p => p.Id == context.InstanceToValidate.PersonId, cancellation);                
                if (!hasPerson)                
                    context.AddFailure($"با شناسه کاربر ارسالی موردی یافت نشد");

                var hasAccessGroup = await _accessGroupQueryRepository.AnyAsync(p => p.Id == context.InstanceToValidate.AccessGroupId, cancellation);
                if (!hasAccessGroup)                
                    context.AddFailure($"با شناسه گروه دسترسی ارسالی موردی یافت نشد");
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
