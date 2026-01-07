using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.PersonAccessGroups.Contracts;

namespace NgCrm.BasicInfoService.Application.AccessGroups.Commands
{
    public class DeleteAccessGroupCommandValidator : AbstractValidator<DeleteAccessGroupCommand>
    {        
        private readonly IPersonAccessGroupQueryRepository _personAccessGroupQueryRepository;
        public DeleteAccessGroupCommandValidator(IPersonAccessGroupQueryRepository personAccessGroupQueryRepository)
        {
            _personAccessGroupQueryRepository = personAccessGroupQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteAccessGroupCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var personAccessGroups = await _personAccessGroupQueryRepository.GetByAccessGroupIdAsync(context.InstanceToValidate.Id, cancellation);

                if (personAccessGroups.Count() > 0)
                {
                    var personNames = String.Join(" - ", personAccessGroups.Select(e => e.Person.FirstName + " " + e.Person.LastName));
                    context.AddFailure($"افراد زیر از این گروه کاربری استفاده کرده اند \n {personNames}");
                }
            });

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
