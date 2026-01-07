using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Roles.Enums
{
    public enum RoleTypes
    {
        [Description("خالی")]
        None = 1,

        [Description("مدیر")]
        Admin = 2,
    }
}
