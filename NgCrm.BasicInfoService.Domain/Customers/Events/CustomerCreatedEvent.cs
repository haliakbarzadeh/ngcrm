using Goldiran.Framework.Domain.Events;
using NgCrm.BasicInfoService.Domain.Customers.Entities;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Customers.Events
{
    public class CustomerCreatedEvent : CreatedDomainEvent
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public CustomerTypes CustomerType { get; private set; }
        public bool IsIranian { get; private set; }
        public string CompanyName { get; private set; }
        public string BrandName { get; private set; }
        public string NationalCode { get; private set; }
        public GenderTypes GenderType { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsVIP { get; private set; }
        public long? CustomerTitleId { get; private set; }
        public long? NationalityId { get; private set; }
        public VipReasonTypes? VipReasonType { get;private set; }
        public long? PositionId { get; private set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; private set; } = new List<CustomerAddress>();

        public CustomerCreatedEvent(Guid businessId,
        string firstName,
        string lastName,
        CustomerTypes customerType,
        bool isIranian,
        string companyName,
        string brandName,
        string nationalCode,
        GenderTypes genderType,
        bool isVIP,
        long? customerTitleId,
        long? nationalityId,
        VipReasonTypes? vipReasonType,
        bool isActive,
        long? positionId,
        ICollection<CustomerAddress> customerAddresses,
         DateTime createdAt) : base(businessId, createdAt)
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
            IsIranian = isIranian;
            CompanyName = companyName;
            BrandName = brandName;
            NationalCode = nationalCode;
            GenderType = genderType;
            IsVIP = isVIP;
            CustomerTitleId = customerTitleId;
            NationalityId = nationalityId;
            VipReasonType = vipReasonType;
            IsActive = isActive;
            PositionId = positionId;
            CustomerAddresses = customerAddresses;
        }


    }
}
