using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.PersonDelegates.Enums
{
    public enum DelegateReasonTypes
    {
        [Description("مرخصی")]
        Vacation = 1,

        [Description("ماموریت")]
        Mission = 2,

        [Description("جانشینی")]
        Delegate = 3,
    }
}
