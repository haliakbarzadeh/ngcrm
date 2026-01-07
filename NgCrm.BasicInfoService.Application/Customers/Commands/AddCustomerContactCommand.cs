using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class AddCustomerContactCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public CustomerContactDto CustomerContact { get; set; }
    }

    public class AddCustomerContactCommandHandler : IRequestHandler<AddCustomerContactCommand, bool>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public AddCustomerContactCommandHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }

        public async Task<bool> Handle(AddCustomerContactCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerCommandRepository.GetByIdAsync(request.Id, e => e.CustomerContacts);

            if (request.CustomerContact.Id == 0)
            {
                customer.AddContact(new CustomerContact(customer.Id, request.CustomerContact.CallTypeId, request.CustomerContact.Contact,
                    request.CustomerContact.HasTelegram, request.CustomerContact.HasWhatsaApp, request.CustomerContact.HasBale, request.CustomerContact.HasIta,
                     request.CustomerContact.IsActive,request.CustomerContact.HasContact,request.CustomerContact.HasSMS,request.CustomerContact.CustomerContactTypeId, request.CustomerContact.SocialMediaTypeId));
            }
            else
            {
                customer.UpdateContact(request.CustomerContact.Id, new CustomerContact(customer.Id, request.CustomerContact.CallTypeId, request.CustomerContact.Contact,
                    request.CustomerContact.HasTelegram, request.CustomerContact.HasWhatsaApp, request.CustomerContact.HasBale, request.CustomerContact.HasIta,
                     request.CustomerContact.IsActive, request.CustomerContact.HasContact, request.CustomerContact.HasSMS, request.CustomerContact.CustomerContactTypeId, request.CustomerContact.SocialMediaTypeId));

            }


            _customerCommandRepository.Update(customer);

            var result = await _customerCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
