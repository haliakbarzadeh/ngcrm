using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Enums
{
    public enum DelegateStatusTypes
    {
        [Description("ثبت شده")]
        Submitted = 1,

        [Description("تایید شده")]
        Confirmed = 2,

        [Description("رد شده")]
        Rejected = 3,
    }
}
