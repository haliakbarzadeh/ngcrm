using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Users.Enums
{
    public enum AccountTypes
    {
        [Description("حساب سازمانی")]
        ActiveDirectory = 1,

        [Description("حساب محلی")]
        Local = 2,

    }
}
