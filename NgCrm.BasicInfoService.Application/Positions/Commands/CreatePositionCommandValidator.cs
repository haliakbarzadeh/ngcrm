using FluentValidation;
using FluentValidation.Results;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<CreatePositionCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("لطفا اسم فارسی را وارد کنید");
            //RuleFor(x => x.Name).NotEmpty().WithMessage("لطفا اسم انگلیسی را وارد کنید");
            RuleFor(x => x.WorkspaceId).NotEmpty().WithMessage("فضای کاری را وارد کنید");
            RuleFor(x => x.OrganizationId).NotEmpty().WithMessage("ساختار سازمانی را وارد کنید");
            RuleFor(x => x.PositionTypeId).NotEmpty().WithMessage("نوع را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
