using Goldiran.Framework.Domain;
using NgCrm.BasicInfoService.Domain.Common.Enums;
using NgCrm.BasicInfoService.Domain.BaseInfos.Entities;

namespace NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels
{
    public class BaseInfoReadModel : ReadModel
    {
        public BaseInfoReadModel()
        {
        }

        public BaseInfoTypes BaseInfoTypeId { get; set; }
        public string DisplayValue { get; set; }
        public string Value { get; set; }
        public bool IsActive { get; set; }

    }
}