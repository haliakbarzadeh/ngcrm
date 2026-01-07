using FluentValidation;
using FluentValidation.Results;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        private readonly ICustomerQueryRepository _customerQueryRepository;
        public DeleteCustomerCommandValidator(ICustomerQueryRepository customerQueryRepository)
        {
            _customerQueryRepository = customerQueryRepository;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteCustomerCommand> context, CancellationToken cancellation = default)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("لطفا شناسه را وارد کنید");

            return await base.ValidateAsync(context, cancellation);
        }
    }
}
