using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class AddPersonPositionPermissionsCommandValidator : AbstractValidator<AddPersonPositionPermissionsCommand>
    {
        private readonly IPersonQueryRepository _personQueryRepository;

        public AddPersonPositionPermissionsCommandValidator(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddPersonPositionPermissionsCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.PersonId).NotEmpty().WithMessage("لطفا شناسه کاربر را وارد کنید");
            RuleFor(x => x.PersonPositionId).NotEmpty().WithMessage("لطفا سمت شخص را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var person = await _personQueryRepository.GetByIdAsync(model.PersonId, cancellation, e => e.PersonPositions);

                if (person is null)
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");

                if(!person.PersonPositions.Any(e=>e.Id == model.PersonPositionId))
                    context.AddFailure($"سمت شخص برای کاربر نیست ");

            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
