using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Common.Utils;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public UpdateCustomerCommandValidator(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdateCustomerCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.NationalCode).NotEmpty().WithMessage("لطفا کد ملی را وارد کنید");
            RuleFor(x => x).Must(CheckNationalCode).WithMessage("کد ملی معتبر نمی باشد");
            RuleFor(x => x).Must(CheckIdentityInfo).WithMessage("لطفا اطلاعات هویتی شامل نام و نام خانوادگی یا نام شرکت را وارد کنید");
            RuleFor(x => x).Must(CheckIntroduced).WithMessage("لطفا اطلاعا معرف را وارد کنید");
            RuleFor(x => x.CustomerTypeId).NotEmpty().WithMessage("لطفا نوع مشتری را وارد کنید");
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("لطفا وضعیت را وارد کنید");

            RuleForEach(x => x.CustomerAddresses)
                .SetValidator(x => new CustomerAddressValidator());

            RuleForEach(x => x.CustomerContacts)
                .SetValidator(x => new CustomerContactValidator());

            RuleForEach(x => x.CustomerRelations)
                .SetValidator(x => new CustomerRelationValidator());

            return await base.ValidateAsync(context, cancellation);
        }

        private bool CheckNationalCode(UpdateCustomerCommand command)
        {
            if (!string.IsNullOrEmpty(command.NationalCode) && command.IsIranian && command.CustomerTypeId == CustomerTypes.Real)
            {
                return PersonUtility.IsNationalCode(command.NationalCode);
            }
            else if (!string.IsNullOrEmpty(command.NationalCode) && ((!command.IsIranian && command.CustomerTypeId == CustomerTypes.Real) || command.CustomerTypeId == CustomerTypes.Legal) && command.NationalCode.Length != 11)
            {
                return false;
            }

            return true;

        }

        private bool CheckIdentityInfo(UpdateCustomerCommand command)
        {
            if ((command.CustomerTypeId == CustomerTypes.Real && (string.IsNullOrEmpty(command.FirstName) || string.IsNullOrEmpty(command.LastName))) ||
                (command.CustomerTypeId == CustomerTypes.Legal && string.IsNullOrEmpty(command.CompanyName)))
            {
                return false;
            }

            return true;

        }

        private bool CheckIntroduced(UpdateCustomerCommand command)
        {
            if (command.VipReasonTypeId == VipReasonTypes.Introduced && command.IntroPersonId == null)
            {
                return false;
            }

            return true;

        }
    }
}
