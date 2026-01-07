using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Enums
{
    public enum AccessScopeTypes
    {
        [Description("گروه محصول")]
        ProductGroup = 1,

        [Description("انبارها")]
        Warehouses = 2,

        [Description("نمایندگان")]
        Agents = 3,

        [Description("فاکتور")]
        Invoice = 4
    }
}
