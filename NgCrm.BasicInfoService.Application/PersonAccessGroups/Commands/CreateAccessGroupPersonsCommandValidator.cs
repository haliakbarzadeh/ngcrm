using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands
{
    public class CreateAccessGroupPersonsCommandValidator : AbstractValidator<CreateAccessGroupPersonsCommand>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly IAccessGroupQueryRepository _accessGroupQueryRepository;

        public CreateAccessGroupPersonsCommandValidator(IPersonQueryRepository personQueryRepository, IAccessGroupQueryRepository accessGroupQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
            _accessGroupQueryRepository = accessGroupQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreateAccessGroupPersonsCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.PersonIds.Count()).NotEqual(0).WithMessage("لطفا شناسه کاربر را وارد کنید");
            RuleFor(x => x.AccessGroupId).NotEmpty().WithMessage("لطفا گروه دسترسی را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var personCount = await _personQueryRepository.CountAsync(p => context.InstanceToValidate.PersonIds.Contains(p.Id), cancellation);

                if (context.InstanceToValidate.PersonIds.Distinct().Count() != personCount)
                    context.AddFailure($"با شناسه های کاربری ارسالی مواردی یافت نشد");

                var hasAccessGroup = await _accessGroupQueryRepository.AnyAsync(p => p.Id == context.InstanceToValidate.AccessGroupId, cancellation);
                if (!hasAccessGroup)
                    context.AddFailure($"با شناسه گروه دسترسی ارسالی موردی یافت نشد");
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
