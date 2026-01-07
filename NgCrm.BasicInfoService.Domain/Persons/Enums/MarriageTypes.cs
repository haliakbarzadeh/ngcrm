using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Persons.Enums
{
    public enum MarriageTypes
    {
        [Description("مجرد")]
        Single = 1,

        [Description("متأهل")]
        Married = 2,
    }
}
