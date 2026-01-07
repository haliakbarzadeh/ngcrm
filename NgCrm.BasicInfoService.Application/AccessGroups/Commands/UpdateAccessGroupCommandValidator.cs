using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Commands
{
    public class UpdateAccessGroupCommandValidator : AbstractValidator<UpdateAccessGroupCommand>
    {        
        private readonly IPersonQueryRepository _personQueryRepository;
        public UpdateAccessGroupCommandValidator(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateAccessGroupCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا عنوان را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                if (context.InstanceToValidate.PersonIds.Count() > 0)
                {
                    var personCount = await _personQueryRepository.CountAsync(p => context.InstanceToValidate.PersonIds.Distinct().Contains(p.Id), cancellation);

                    if (context.InstanceToValidate.PersonIds.Distinct().Count() != personCount)
                        context.AddFailure($"با شناسه های کاربری ارسالی مواردی یافت نشد");
                }

            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
