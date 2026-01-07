using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Common.Enums;
using Goldiran.Framework.Application.Helpers;

namespace NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;

public class BaseInfoDto : Dto
{
    public long Id { get; set; }
    public BaseInfoTypes BaseInfoTypeId { get; set; }
    public string BaseInfoTypeDesc { get { return BaseInfoTypeId.GetEnumDescription(); } }
    public string DisplayValue { get; set; }
    public string Value { get; set; }
    public bool IsActive { get;  set; }

}
