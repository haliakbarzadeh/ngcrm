using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Positions.Enums
{
    public enum PositionTypes
    {
        [Description("مدیرعامل")]
        CEO = 1,

        [Description("معاونت")]
        Deputy = 2,

        [Description("رئیس")]
        Head = 3,

        [Description("سرپرست")]
        Supervisor = 4,

        [Description("سرگروه")]
        TeamLeader = 5,

        [Description("کارشناس ارشد")]
        SeniorExpert = 6,

        [Description("کارشناس")]
        Expert = 7,

        [Description("کارمند")]
        Employee = 8,

        [Description("تکنسین")]
        Technician = 9,

        [Description("کارگر")]
        Worker = 10
    }
}
