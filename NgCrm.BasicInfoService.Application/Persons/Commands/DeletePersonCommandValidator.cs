using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        public DeletePersonCommandValidator(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeletePersonCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var hasValue = await _personQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation);

                if (hasValue is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                    return;
                }
            });


            return await base.ValidateAsync(context, cancellation);
        }
    }
}
