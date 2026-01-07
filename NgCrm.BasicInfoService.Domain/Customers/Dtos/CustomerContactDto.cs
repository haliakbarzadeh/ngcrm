using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Customers.Enums;

namespace NgCrm.BasicInfoService.Domain.Customers.Dtos
{
    public class CustomerContactDto : Dto
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public CallTypes? CallTypeId { get; set; }
        public string CallTypeDesc { get { return CallTypeId != null ? CallTypeId.GetEnumDescription() : string.Empty; } }
        public CustomerContactTypes CustomerContactTypeId { get; set; }
        public string ContactTypeDesc { get { return CustomerContactTypeId.GetEnumDescription(); } }
        public SocialMediaTypes? SocialMediaTypeId { get; private set; }
        public string SocialMediaTypeDesc { get { return SocialMediaTypeId != null ? SocialMediaTypeId.GetEnumDescription() : string.Empty; } }

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
    }
}
