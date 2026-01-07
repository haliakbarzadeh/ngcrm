using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.BaseInfos.Dtos;
using NgCrm.BasicInfoService.Domain.BaseInfos.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.BaseInfos
{
    public class BaseInfoReadModelMapping : MapProfile<BaseInfoReadModel, BaseInfoDto>
    {
        public BaseInfoReadModelMapping()
        {

        }
    }
}
