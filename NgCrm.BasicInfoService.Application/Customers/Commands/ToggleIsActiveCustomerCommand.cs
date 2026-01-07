using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class ToggleIsActiveCustomerCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class ToggleIsActiveCustomerCommandHandler : IRequestHandler<ToggleIsActiveCustomerCommand, bool>
    {
        private readonly ICustomerCommandRepository _CustomerCommandRepository;


        public ToggleIsActiveCustomerCommandHandler(ICustomerCommandRepository CustomerCommandRepository)
        {
            _CustomerCommandRepository = CustomerCommandRepository;
        }

        public async Task<bool> Handle(ToggleIsActiveCustomerCommand request, CancellationToken cancellationToken)
        {
            var Customer = await _CustomerCommandRepository.GetByIdAsync(request.Id);

            Customer.ToggleIsActive();

            _CustomerCommandRepository.Update(Customer);

            var result = await _CustomerCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
    }
}
