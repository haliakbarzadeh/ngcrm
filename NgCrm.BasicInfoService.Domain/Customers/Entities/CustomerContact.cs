using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.Customers.Enums;

namespace NgCrm.BasicInfoService.Domain.Customers.Entities
{
    [Auditable]
    public class CustomerContact : Entity
    {
        public long CustomerId { get; private set; }
        public CustomerContactTypes CustomerContactTypeId { get; private set; }
        public CallTypes? CallTypeId { get; private set; }
        public SocialMediaTypes? SocialMediaTypeId { get; private set; }
        public string Contact { get; private set; }
        public bool HasTelegram { get; private set; }
        public bool HasWhatsaApp { get; private set; }
        public bool HasBale { get; private set; }
        public bool HasIta { get; private set; }
        public bool HasContact { get; private set; }
        public bool HasSMS { get; private set; }
        public DateTime? ActiveDate { get; private set; }
        public DateTime? DisActiveDate { get; private set; }

        public bool IsActive { get; private set; }

        public CustomerContact(
            long customerId,
            CallTypes? callTypeId,
            string contact,
            bool hasTelegram,
            bool hasWhatsaApp,
            bool hasBale,
            bool hasIta,
            bool isActive,
            bool hasContact,
            bool hasSMS,
            CustomerContactTypes customerContactTypeId,
            SocialMediaTypes? socialMediaTypeId)
        {
            CustomerId = customerId;
            CallTypeId = callTypeId;
            Contact = contact;
            HasTelegram = hasTelegram;
            HasWhatsaApp = hasWhatsaApp;
            HasBale = hasBale;
            HasIta = hasIta;
            IsActive = isActive;
            HasContact = hasContact;
            HasSMS = hasSMS;
            SocialMediaTypeId = socialMediaTypeId;
            CustomerContactTypeId = customerContactTypeId;
            SetActivateDate();
        }

        public void Update(
            long customerId,
            CallTypes? callTypeId,
            string contact,
            bool hasTelegram,
            bool hasWhatsaApp,
            bool hasBale,
            bool hasIta,
            bool isActive,
            bool hasContact,
            bool hasSMS,
            CustomerContactTypes customerContactTypeId,
            SocialMediaTypes? socialMediaTypeId,
            bool isDeleted = false)
        {
            CustomerId = customerId;
            CallTypeId = callTypeId;
            Contact = contact;
            HasTelegram = hasTelegram;
            HasWhatsaApp = hasWhatsaApp;
            HasBale = hasBale;
            HasIta = hasIta;
            IsActive = isActive;
            HasContact = hasContact;
            HasSMS = hasSMS;
            SocialMediaTypeId = socialMediaTypeId;
            CustomerContactTypeId = customerContactTypeId;
            UpdateActivateDate(isActive);
        }

        private void SetActivateDate()
        {
            if (IsActive)
                ActiveDate = DateTime.Now;
            else
                DisActiveDate = DateTime.Now;
        }

        private void UpdateActivateDate(bool isActive)
        {
            if (IsActive && isActive != IsActive)
            {
                ActiveDate = DateTime.Now;
                DisActiveDate = null;
            }
            else if (!IsActive && isActive != IsActive)
            {
                DisActiveDate = DateTime.Now;
            }
        }

    }
}

