using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Locations.Enums
{
    public enum LocationTypes
    {
        [Description("استان")]
        Province = 1,

        [Description("شهر")]
        City = 2,

        [Description("منطقه")]
        Region = 3,
    }
}
