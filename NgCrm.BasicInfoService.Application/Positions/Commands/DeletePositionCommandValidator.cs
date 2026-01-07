using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Permissions.Contracts;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;

namespace NgCrm.BasicInfoService.Application.Positions.Commands
{
    public class DeletePositionCommandValidator : AbstractValidator<DeletePositionCommand>
    {
        private readonly IPositionQueryRepository _positionQueryRepository;
        private readonly IPermissionQueryRepository _permissionQueryRepository;
        private readonly IPersonQueryRepository _personQueryRepository;

        public DeletePositionCommandValidator(IPositionQueryRepository positionQueryRepository,
            IPermissionQueryRepository permissionQueryRepository,
            IPersonQueryRepository personQueryRepository)
        {
            _positionQueryRepository = positionQueryRepository;
            _permissionQueryRepository = permissionQueryRepository;
            _personQueryRepository = personQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeletePositionCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید"); ;

            RuleFor(x => x).CustomAsync(async (model, context, cc) =>
            {
                var position = await _positionQueryRepository.GetByIdAsync(context.InstanceToValidate.Id, cancellation, e => e.PositionPermissions);

                if (position is null)
                {
                    context.AddFailure($"با شناسه ارسالی موردی یافت نشد");
                }

                if (position.PositionPermissions?.Any() == true)
                {
                    var permissionIds = position.PositionPermissions.Select(x => x.PermissionId).ToList();
                    var permissions = await _permissionQueryRepository.GetByIdsAsync(permissionIds, cancellation);

                    var childrenNames = string.Join(" - ", permissions.Select(e => e.Title).ToList());
                    context.AddFailure($"امکان حذف وجود ندارد، نام دسترسی مرتبط با درخواست ارسالی : {childrenNames}");
                }

                var persons = await _personQueryRepository.GetByPositionIdAsync(context.InstanceToValidate.Id, cancellation);

                if (persons?.Any() == true)
                {

                    var personNames = string.Join(" - ", persons.Select(e => e.FirstName + " " + e.LastName).ToList());
                    context.AddFailure($"در این سمت سازمانی فردی تخصیص داده شده است . امکان حذف وجود ندارد.");
                }
            });


            return await base.ValidateAsync(context, cancellation);
        }
    }
}
