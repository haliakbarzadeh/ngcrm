using System.ComponentModel;

namespace NgCrm.BasicInfoService.Domain.Common.Enums;

public enum BaseInfoTypes
{
    [Description("علت VIP")]
    VIPReason = 1,
    [Description("عنوان مشتری")]
    CustomerType = 2,
    [Description("ملیت")]
    Nationality=3,
    [Description("عنوان رابط")]
    CustomerRelation = 4

}
