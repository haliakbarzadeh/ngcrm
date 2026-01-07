using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class AddCustomerAddressCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public CustomerAddressDto CustomerAddress { get; set; }
    }

    public class AddCustomerAddressCommandHandler : IRequestHandler<AddCustomerAddressCommand, bool>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public AddCustomerAddressCommandHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }

        public async Task<bool> Handle(AddCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerCommandRepository.GetByIdAsync(request.Id, e => e.CustomerAddresses);

            if (request.CustomerAddress.Id == 0)
            {
                customer.AddAddress(new CustomerAddress(customer.Id, request.CustomerAddress.Latitude, request.CustomerAddress.Longitude,
                    request.CustomerAddress.ProvinceId, request.CustomerAddress.CountyId, request.CustomerAddress.City, request.CustomerAddress.District,
                    request.CustomerAddress.Village, request.CustomerAddress.Zone, request.CustomerAddress.Place, request.CustomerAddress.Street,
                    request.CustomerAddress.Details, request.CustomerAddress.PostalCode, request.CustomerAddress.IsActive));
            }
            else
            {
                customer.UpdateAddress(request.CustomerAddress.Id, new CustomerAddress(customer.Id, request.CustomerAddress.Latitude, request.CustomerAddress.Longitude,
                    request.CustomerAddress.ProvinceId, request.CustomerAddress.CountyId, request.CustomerAddress.City, request.CustomerAddress.District,
                    request.CustomerAddress.Village, request.CustomerAddress.Zone, request.CustomerAddress.Place, request.CustomerAddress.Street,
                    request.CustomerAddress.Details, request.CustomerAddress.PostalCode, request.CustomerAddress.IsActive));

            }


            _customerCommandRepository.Update(customer);

            var result = await _customerCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
