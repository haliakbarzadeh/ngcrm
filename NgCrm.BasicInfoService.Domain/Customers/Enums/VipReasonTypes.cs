using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Customers.Enums
{
    public enum VipReasonTypes
    {
        [Description("معمولی")]
        Ordinary = 1,
        [Description("معرفی شده از طرف مدیران ارشد")]
        Introduced = 2,
        [Description("سلبریتی و مسؤولین دواتی")]
        Governmental = 3,
        [Description("دیپلمات/سفیر")]
        Diplomat = 4,

    }



}
