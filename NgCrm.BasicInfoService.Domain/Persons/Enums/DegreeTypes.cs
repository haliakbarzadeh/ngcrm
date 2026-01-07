using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Persons.Enums
{
    public enum DegreeTypes
    {
        [Description("بی سواد")]
        Illiterate = 1,

        [Description("زیر دیپلم")]
        BelowDiploma = 2,

        [Description("دیپلم")]
        Diploma = 3,

        [Description("کاردانی")]
        Associate = 4,

        [Description("کارشناسی")]
        Bachelor = 5,

        [Description("کارشناسی ارشد")]
        Master = 6,

        [Description("دکترا")]
        Doctorate = 7
    }
}
