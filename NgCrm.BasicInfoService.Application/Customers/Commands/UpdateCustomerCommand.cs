using Goldiran.Framework.Application.Commands;
using MediatR;
using NgCrm.BasicInfoService.Domain.Customers.Contracts;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Application.Customers.Commands
{
    public class UpdateCustomerCommand : BaseCommandRequest, IRequest<bool>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerTypes CustomerTypeId { get; set; }
        public bool IsIranian { get; set; }
        public string CompanyName { get; set; }
        public string BrandName { get; set; }
        public string NationalCode { get; set; }
        public GenderTypes? GenderTypeId { get; set; }
        public bool IsActive { get; set; }
        public bool IsVIP { get; set; }
        public long? CustomerTitleId { get; set; }
        public long? NationalityId { get; set; }
        public VipReasonTypes? VipReasonTypeId { get; set; }
        public long? IntroPersonId { get; set; }
        public DegreeTypes? DegreeTypeId { get; set; }
        public MarriageTypes? MarriageTypeId { get; set; }
        public DateTime? BirthDate { get; set; }
        public long? BirthPlaceId { get; set; }
        public long? RegisteryPlaceId { get; set; }
        public IEnumerable<CustomerAddressDto> CustomerAddresses { get; set; } = Enumerable.Empty<CustomerAddressDto>();
        public IEnumerable<CustomerContactDto> CustomerContacts { get; set; } = Enumerable.Empty<CustomerContactDto>();
        public IEnumerable<CustomerRelationDto> CustomerRelations { get; set; } = Enumerable.Empty<CustomerRelationDto>();

    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public UpdateCustomerCommandHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }

        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerCommandRepository.GetByIdAsync(request.Id, e => e.CustomerAddresses,e=>e.CustomerContacts);

            customer.Update(request.FirstName, request.LastName, request.CustomerTypeId, request.IsIranian, request.CompanyName, request.BrandName,
                            request.NationalCode, request.GenderTypeId, request.IsVIP, request.CustomerTitleId, request.NationalityId,
                            request.VipReasonTypeId, request.IsActive, request.IntroPersonId, request.DegreeTypeId, request.MarriageTypeId,
                            request.BirthDate, request.BirthPlaceId,request.RegisteryPlaceId);

            customer.UpdateCustomerAddresses(request.CustomerAddresses);
            customer.UpdateCustomerContacts(request.CustomerContacts);
            customer.UpdateCustomerRelations(request.CustomerRelations);


            _customerCommandRepository.Update(customer);

            var result = await _customerCommandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
    }
}
