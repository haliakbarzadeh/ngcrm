using Goldiran.Framework.Domain;
using Goldiran.Framework.Domain.Attributes;
using NgCrm.BasicInfoService.Domain.Common.Enums;

namespace NgCrm.BasicInfoService.Domain.BaseInfos.Entities
{
    [Auditable]
    public class BaseInfo : AggregateRoot
    {
        public BaseInfoTypes BaseInfoTypeId { get; private set; }
        public string DisplayValue { get; private set; }
        public string Value { get; private set; }
        public bool IsActive { get; private set; }

        public BaseInfo(BaseInfoTypes baseInfoTypeId,
        string displayValue,
        string value,
        bool isActive)
        {
            BaseInfoTypeId = baseInfoTypeId;
            DisplayValue = displayValue;
            Value = value;
            IsActive = isActive;

        }

        public void Update(BaseInfoTypes baseInfoTypeId,
        string displayValue,
        string value,
        bool isActive)
        {
            BaseInfoTypeId = baseInfoTypeId;
            DisplayValue = displayValue;
            Value = value;
            IsActive = isActive;

        }

    }
}