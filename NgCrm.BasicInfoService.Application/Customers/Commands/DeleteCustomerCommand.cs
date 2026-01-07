using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class DeleteCustomerCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public DeleteCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerCommandRepository.GetByIdAsync(request.Id);

            customer.Archive();


            _customerCommandRepository.Update(customer);
            var result = await _customerCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return 1 > 0;
        }
    }
}
