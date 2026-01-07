using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Common.Utils;
using NgCrm.BasicInfoService.Domain.Persons.Contracts;

namespace NgCrm.BasicInfoService.Application.Persons.Commands
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        private readonly IPersonQueryRepository _personQueryRepository;
        public UpdatePersonCommandValidator(IPersonQueryRepository personQueryRepository)
        {
            _personQueryRepository = personQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<UpdatePersonCommand> context, CancellationToken cancellation = default)
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

           
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("لطفا وضعیت را وارد کنید");

            if (context.InstanceToValidate.IsLegal)
            {
                RuleFor(x => x.CompanyName).NotEmpty().WithMessage("لطفا نام شرکت را وارد کنید");
                RuleFor(x => x.ContactName).NotEmpty().WithMessage("لطفا رابط را وارد کنید");
                RuleFor(x => x.RegistrationNumber).NotEmpty().WithMessage("لطفا شماره ثبت را وارد کنید");
                RuleFor(x => x.NationalCode)
                   .NotEmpty().WithMessage("شناسه ملی شرکت الزامی است")
                   .Length(11).WithMessage("لطفا شناسه ملی شرکت را به صورت 11 رقمی وارد کنید");
            }
            else
            {
                RuleFor(x => x.FirstName).NotEmpty().WithMessage("لطفا نام را وارد کنید");
                RuleFor(x => x.LastName).NotEmpty().WithMessage("لطفا نام خانوادگی را وارد کنید");
                RuleFor(x => x.FatherName).NotEmpty().WithMessage("لطفا نام پدر را وارد کنید");
                RuleFor(x => x.NationalCode).Must(PersonUtility.IsNationalCode).WithMessage("لطفا کد ملی را وارد کنید");


                RuleFor(x => x.GenderTypeId).NotEmpty().WithMessage("لطفا جنسیت را وارد کنید");

                RuleFor(x => x.MarriageTypeId).NotEmpty().WithMessage("لطفا وضعیت تاهل را وارد کنید");
                RuleFor(x => x.BirthDate).NotEmpty().WithMessage("لطفا تاریخ تولد را وارد کنید");
                RuleFor(x => x.BirthPlace).NotEmpty().WithMessage("لطفا محل تولد را وارد کنید");

                //RuleFor(x => x.PersonalCode).NotEmpty().WithMessage("لطفا کد پرسنلی را وارد کنید");
                RuleFor(x => x.DegreeTypeId).NotEmpty().WithMessage("لطفا مدرک تحصیلی را وارد کنید");
                RuleFor(x => x.Major).NotEmpty().WithMessage("لطفا رشته تحصیلی را وارد کنید");
            }


            return await base.ValidateAsync(context, cancellation);
        }
    }
}
