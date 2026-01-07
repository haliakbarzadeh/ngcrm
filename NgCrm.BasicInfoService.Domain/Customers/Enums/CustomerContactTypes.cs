using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Customers.Enums;

public enum CustomerContactTypes
{
    [Description("تلفن")]
    Phone = 1,

    [Description("ایمیل")]
    Email = 2,

    [Description("شبکه اجتماعی")]
    SocialMedia = 3
}
