using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.Customers.Dtos;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Customers.Entities
{
    [Auditable]
    public class Customer : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public CustomerTypes CustomerTypeId { get; private set; }
        public bool IsIranian { get; private set; }
        public string CompanyName { get; private set; }
        public string BrandName { get; private set; }
        public string NationalCode { get; private set; }
        public GenderTypes? GenderTypeId { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsVIP { get; private set; }
        public VipReasonTypes? VipReasonTypeId { get; private set; }
        public long? CustomerTitleId { get; private set; }
        public long? NationalityId { get; private set; }
        public long? IntroPersonId { get; private set; }
        public DegreeTypes? DegreeTypeId { get; private set; }
        public MarriageTypes? MarriageTypeId { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public long? BirthPlaceId { get; private set; }
        public long? RegisteryPlaceId { get; private set; }
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; private set; } = new List<CustomerAddress>();
        public virtual ICollection<CustomerContact> CustomerContacts { get; private set; } = new List<CustomerContact>();
        public virtual ICollection<CustomerRelation> CustomerRelations { get; private set; } = new List<CustomerRelation>();

        public Customer(string firstName,
        string lastName,
        CustomerTypes customerTypeId,
        bool isIranian,
        string companyName,
        string brandName,
        string nationalCode,
        GenderTypes? genderTypeId,
        bool isVIP,
        long? customerTitleId,
        long? nationalityId,
        VipReasonTypes? vipReasonTypeId,
        bool isActive,
        long? introPersonId,
        DegreeTypes? degreeTypeId,
        MarriageTypes? marriageTypeId,
        DateTime? birthDate,
        long? birthPlaceId,
        long? registeryPlaceId
        )
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerTypeId = customerTypeId;
            IsIranian = isIranian;
            CompanyName = companyName;
            BrandName = brandName;
            NationalCode = nationalCode;
            GenderTypeId = genderTypeId;
            IsVIP = isVIP;
            CustomerTitleId = customerTitleId;
            NationalityId = nationalityId;
            VipReasonTypeId = vipReasonTypeId;
            IsActive = isActive;
            IntroPersonId = introPersonId;
            DegreeTypeId = degreeTypeId;
            MarriageTypeId = marriageTypeId;
            BirthDate = birthDate;
            BirthPlaceId = birthPlaceId;
            RegisteryPlaceId = registeryPlaceId;

        }

        public void Update(string firstName,
        string lastName,
        CustomerTypes customerTypeId,
        bool isIranian,
        string companyName,
        string brandName,
        string nationalCode,
        GenderTypes? genderTypeId,
        bool isVIP,
        long? customerTitleId,
        long? nationalityId,
        VipReasonTypes? vipReasonTypeId,
        bool isActive,
        long? introPersonId,
        DegreeTypes? degreeTypeId,
        MarriageTypes? marriageTypeId,
        DateTime? birthDate,
        long? birthPlaceId,
        long? registeryPlaceId
        )
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerTypeId = customerTypeId;
            IsIranian = isIranian;
            CompanyName = companyName;
            BrandName = brandName;
            NationalCode = nationalCode;
            GenderTypeId = genderTypeId;
            IsVIP = isVIP;
            CustomerTitleId = customerTitleId;
            NationalityId = nationalityId;
            VipReasonTypeId = vipReasonTypeId;
            IsActive = isActive;
            IntroPersonId = introPersonId;
            DegreeTypeId = degreeTypeId;
            MarriageTypeId = marriageTypeId;
            BirthDate = birthDate;
            BirthPlaceId = birthPlaceId;
            RegisteryPlaceId = registeryPlaceId;
        }


        public void SetCustomerAddresses(IEnumerable<CustomerAddress> customerAddresses)
        {
            CustomerAddresses = customerAddresses.ToList();
        }

        public void UpdateCustomerAddresses(IEnumerable<CustomerAddressDto> customerAddresses)
        {
            var removeList = CustomerAddresses.Where(e => !customerAddresses.Select(c => c.Id).Contains(e.Id));
            foreach (var item in removeList)
            {
                DeleteAddress(item.Id, new CustomerAddress(item.CustomerId, item.Latitude, item.Longitude, item.ProvinceId, item.CountyId, item.City, item.District, item.Village, item.Zone, item.Place, item.Street, item.Details, item.PostalCode, item.IsActive));
            }

            var updateList = customerAddresses.Where(e => CustomerAddresses.Select(c => c.Id).Contains(e.Id));
            foreach (var item in updateList)
            {
                UpdateAddress(item.Id, new CustomerAddress(Id, item.Latitude, item.Longitude, item.ProvinceId, item.CountyId, item.City, item.District, item.Village, item.Zone, item.Place, item.Street, item.Details, item.PostalCode, item.IsActive));
            }

            var addedList = customerAddresses.Where(c => c.Id == 0).ToList();
            foreach (var item in addedList)
            {
                AddAddress(new CustomerAddress(Id, item.Latitude, item.Longitude, item.ProvinceId, item.CountyId, item.City, item.District, item.Village, item.Zone, item.Place, item.Street, item.Details, item.PostalCode, item.IsActive));
            }
        }


        public void AddAddress(CustomerAddress customerAddress)
        {
            CustomerAddresses.Add(customerAddress);
        }

        public void UpdateAddress(long id, CustomerAddress customerAddress)
        {
            var item = CustomerAddresses.FirstOrDefault(e => e.Id == id);
            item.Update(item.CustomerId, customerAddress.Latitude, customerAddress.Longitude, customerAddress.ProvinceId, customerAddress.CountyId, customerAddress.City, customerAddress.District, customerAddress.Village, customerAddress.Zone, customerAddress.Place, customerAddress.Street, customerAddress.Details, customerAddress.PostalCode, customerAddress.IsActive, false);

        }

        public void DeleteAddress(long id, CustomerAddress customerAddress)
        {
            var item = CustomerAddresses.FirstOrDefault(e => e.Id == id);
            item.Update(item.CustomerId, customerAddress.Latitude, customerAddress.Longitude, customerAddress.ProvinceId, customerAddress.CountyId, customerAddress.City, customerAddress.District, customerAddress.Village, customerAddress.Zone, customerAddress.Place, customerAddress.Street, customerAddress.Details, customerAddress.PostalCode, customerAddress.IsActive, true);


        }

        public void SetCustomerContacts(IEnumerable<CustomerContact> customerContactes)
        {
            CustomerContacts = customerContactes.ToList();
        }

        public void UpdateCustomerContacts(IEnumerable<CustomerContactDto> customerContacts)
        {
            var removeList = CustomerContacts.Where(e => !customerContacts.Select(c => c.Id).Contains(e.Id));
            foreach (var item in removeList)
            {
                DeleteContact(item.Id, new CustomerContact(item.CustomerId, item.CallTypeId, item.Contact, item.HasTelegram, item.HasWhatsaApp, item.HasBale, item.HasIta, item.IsActive, item.HasContact, item.HasSMS, item.CustomerContactTypeId, item.SocialMediaTypeId));
            }

            var updateList = customerContacts.Where(e => CustomerContacts.Select(c => c.Id).Contains(e.Id));
            foreach (var item in updateList)
            {
                UpdateContact(item.Id, new CustomerContact(Id, item.CallTypeId, item.Contact, item.HasTelegram, item.HasWhatsaApp, item.HasBale, item.HasIta, item.IsActive, item.HasContact, item.HasSMS, item.CustomerContactTypeId, item.SocialMediaTypeId));
            }

            var addedList = customerContacts.Where(c => c.Id == 0).ToList();
            foreach (var item in addedList)
            {
                AddContact(new CustomerContact(Id, item.CallTypeId, item.Contact, item.HasTelegram, item.HasWhatsaApp, item.HasBale, item.HasIta, item.IsActive, item.HasContact, item.HasSMS, item.CustomerContactTypeId, item.SocialMediaTypeId));
            }
        }


        public void AddContact(CustomerContact customerContact)
        {
            CustomerContacts.Add(customerContact);
        }

        public void UpdateContact(long id, CustomerContact customerContact)
        {
            var item = CustomerContacts.FirstOrDefault(e => e.Id == id);
            item.Update(item.CustomerId, customerContact.CallTypeId, customerContact.Contact, customerContact.HasTelegram, customerContact.HasWhatsaApp, customerContact.HasBale, customerContact.HasIta, customerContact.IsActive, customerContact.HasContact, customerContact.HasSMS, customerContact.CustomerContactTypeId, customerContact.SocialMediaTypeId, false);

        }

        public void DeleteContact(long id, CustomerContact customerContact)
        {
            var item = CustomerContacts.FirstOrDefault(e => e.Id == id);
            item.Update(item.CustomerId, customerContact.CallTypeId, customerContact.Contact, customerContact.HasTelegram, customerContact.HasWhatsaApp, customerContact.HasBale, customerContact.HasIta, customerContact.IsActive, customerContact.HasContact, customerContact.HasSMS, customerContact.CustomerContactTypeId, customerContact.SocialMediaTypeId, true);


        }

        public void SetCustomerRelations(IEnumerable<CustomerRelation> customerRelations)
        {
            CustomerRelations = customerRelations.ToList();
        }

        public void UpdateCustomerRelations(IEnumerable<CustomerRelationDto> customerRelations)
        {
            var removeList = CustomerRelations.Where(e => !customerRelations.Select(c => c.Id).Contains(e.Id));
            foreach (var item in removeList)
            {
                DeleteRelation(item.Id, new CustomerRelation(item.CustomerId, item.FirstName, item.LastName, item.NationalCode, item.MobileNumber, item.FixNumber, item.RelationTitleId));
            }

            var updateList = customerRelations.Where(e => CustomerRelations.Select(c => c.Id).Contains(e.Id));
            foreach (var item in updateList)
            {
                UpdateRelation(item.Id, new CustomerRelation(Id, item.FirstName, item.LastName, item.NationalCode, item.MobileNumber, item.FixNumber, item.RelationTitleId));
            }

            var addedList = customerRelations.Where(c => c.Id == 0).ToList();
            foreach (var item in addedList)
            {
                AddRelation(new CustomerRelation(Id, item.FirstName, item.LastName, item.NationalCode, item.MobileNumber, item.FixNumber, item.RelationTitleId));
            }
        }


        public void AddRelation(CustomerRelation customerRelation)
        {
            CustomerRelations.Add(customerRelation);
        }

        public void UpdateRelation(long id, CustomerRelation customerRelation)
        {
            var item = CustomerRelations.FirstOrDefault(e => e.Id == id);
            item.Update(item.CustomerId, customerRelation.FirstName, customerRelation.LastName, customerRelation.NationalCode, customerRelation.MobileNumber, customerRelation.FixNumber, customerRelation.RelationTitleId, false);

        }

        public void DeleteRelation(long id, CustomerRelation customerRelation)
        {
            var item = CustomerRelations.FirstOrDefault(e => e.Id == id);
            item.Update(item.CustomerId, customerRelation.FirstName, customerRelation.LastName, customerRelation.NationalCode, customerRelation.MobileNumber, customerRelation.FixNumber, customerRelation.RelationTitleId, true);


        }

        public void ToggleIsActive()
        {
            IsActive = !IsActive;
            ModifiedAt = DateTime.Now;
        }

    }
}