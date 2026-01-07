using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class AddCustomerRelationCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public CustomerRelationDto CustomerRelation { get; set; }
    }

    public class AddCustomerRelationCommandHandler : IRequestHandler<AddCustomerRelationCommand, bool>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public AddCustomerRelationCommandHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }

        public async Task<bool> Handle(AddCustomerRelationCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerCommandRepository.GetByIdAsync(request.Id, e => e.CustomerRelations);

            if (request.CustomerRelation.Id == 0)
            {
                customer.AddRelation(new CustomerRelation(customer.Id, request.CustomerRelation.FirstName, request.CustomerRelation.LastName,
                    request.CustomerRelation.NationalCode, request.CustomerRelation.MobileNumber, request.CustomerRelation.FixNumber, request.CustomerRelation.RelationTitleId));
            }
            else
            {
                customer.UpdateRelation(request.CustomerRelation.Id, new CustomerRelation(customer.Id, request.CustomerRelation.FirstName, request.CustomerRelation.LastName,
                    request.CustomerRelation.NationalCode, request.CustomerRelation.MobileNumber, request.CustomerRelation.FixNumber, request.CustomerRelation.RelationTitleId));

            }

            _customerCommandRepository.Update(customer);

            var result = await _customerCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
