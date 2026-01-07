using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Permissions.Enums
{
    public enum PermissionTypes
    {
        [Description("منو")]
        Menu = 1,
        [Description("زیر منو")]
        SubMenu = 2,
        [Description("عملیات")]
        Action = 3
    }
}
