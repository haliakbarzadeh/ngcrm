using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Customers.Enums
{
    public enum CallTypes
    {
        [Description("تلفن منزل")]
        House = 1,

        [Description("تلفن محل کار")]
        Work = 2,
        [Description("تلفن همراه شخصی")]
        Personal = 1,

        [Description("تلفن شرکت")]
        Company = 2

    }



}
