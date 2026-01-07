using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Customers.Enums;
using NgCrm.BasicInfoService.Domain.Persons.Enums;

namespace NgCrm.BasicInfoService.Domain.Customers.ReadModels
{
    public class CustomerContactReadModel : ReadModel
    {
        public long CustomerId { get; set; }
        public CustomerContactTypes CustomerContactTypeId { get; private set; }
        public CallTypes? CallTypeId { get; private set; }
        public SocialMediaTypes? SocialMediaTypeId { get; private set; }
        public string Contact { get; set; }
        public bool HasTelegram { get; set; }
        public bool HasWhatsaApp { get; set; }
        public bool HasBale { get; set; }
        public bool HasIta { get; set; }
        public bool IsActive { get; set; }
        public bool HasContact { get; set; }
        public bool HasSMS { get; set; }
        public DateTime? ActiveDate { get; set; }
        public DateTime? DisActiveDate { get; set; }
        public CustomerReadModel Customer { get; set; }

    }
}
