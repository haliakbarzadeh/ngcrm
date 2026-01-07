using FluentValidation;

namespace NgCrm.BasicInfoService.Application.PersonDelegates.Commands
{
    public class UpdatePersonDelegateCommandValidator : AbstractValidator<UpdatePersonDelegateCommand>
    {
        public UpdatePersonDelegateCommandValidator()
        {
            RuleFor(x => x.AssignerPersonId)
                  .GreaterThan(0)
                  .WithMessage("واگذارکننده نباید خالی باشد");

            RuleFor(x => x.AssignerPositionId)
                .GreaterThan(0)
                .WithMessage("سمت واگذارکننده نباید خالی باشد");

            RuleFor(x => x.DelegatePersonId)
                .GreaterThan(0)
                .WithMessage("جانشین نباید خالی باشد");

            RuleFor(x => x.FromDate)
                .NotEmpty()
                .WithMessage("تاریخ شروع نباید خالی باشد");

            RuleFor(x => (int)x.ReasonTypeId)
                .GreaterThan(0)
                .WithMessage("دلیل نباید خالی باشد");

            RuleFor(x => (int)x.StatusTypeId)
                .GreaterThan(0)
                .WithMessage("وضعیت نباید خالی باشد");

            RuleFor(x => x.ToDate)
                .GreaterThan(x => x.FromDate)
                .When(x => x.ToDate.HasValue)
                .WithMessage("تاریخ پایان باید از تاریخ شروع بزرگتر باشد");
        }
    }
}