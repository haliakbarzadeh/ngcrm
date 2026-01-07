using FluentValidation;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Commands
{
    public class DeletePersonDelegateCommandValidator : AbstractValidator<DeletePersonDelegateCommand>
    {
        public DeletePersonDelegateCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("‘‰«”Â «‰ Œ«» ‰‘œÂ «” ");
        }
    }
}