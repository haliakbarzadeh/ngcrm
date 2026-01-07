using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.AccessGroups.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.PersonAccessGroups.Commands
{
    public class CreatePersonAccessGroupsCommandValidator : AbstractValidator<CreatePersonAccessGroupsCommand>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        private readonly IAccessGroupQueryRepository _accessGroupQueryRepository;

        public CreatePersonAccessGroupsCommandValidator(IPersonQueryRepository personQueryRepository, IAccessGroupQueryRepository accessGroupQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
            _accessGroupQueryRepository = accessGroupQueryRepository;
        }      

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreatePersonAccessGroupsCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.PersonId).NotEmpty().WithMessage("لطفا شناسه کاربر را وارد کنید");
            RuleFor(x => x.AccessGroupIds.Count()).NotEqual(0).WithMessage("لطفا گروه دسترسی را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var hasPerson = await _personQueryRepository.AnyAsync(p => p.Id == context.InstanceToValidate.PersonId, cancellation);
                if (!hasPerson)
                    context.AddFailure($"با شناسه کاربر ارسالی موردی یافت نشد");

                var accessGroupCount = await _accessGroupQueryRepository.CountAsync(p => context.InstanceToValidate.AccessGroupIds.Contains(p.Id), cancellation);
                if (context.InstanceToValidate.AccessGroupIds.Distinct().Count() != accessGroupCount)
                    context.AddFailure($"با شناسه های کاربری ارسالی مواردی یافت نشد");
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
