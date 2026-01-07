using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Persons.Enums
{
    public enum PersonContactTypes
    {
        [Description("موبایل")]
        Mobile = 1,

        [Description("ایمیل")]
        Email = 2,

        [Description("تلفن ثابت")]
        Phone = 3
    }
}
