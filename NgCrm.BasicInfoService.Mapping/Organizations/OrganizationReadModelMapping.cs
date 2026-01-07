using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Organizations.Dtos;
using NgCrm.BasicInfoService.Domain.Organizations.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Organizations
{
    public class OrganizationReadModelMapping : MapProfile<OrganizationReadModel, OrganizationDto>
    {
        public OrganizationReadModelMapping()
        {
            ForMember(x => x.PositionDtos, x => x.Positions);
            ForMember(x => x.OrganizationTypeTitle, x => x.OrganizationTypeId.GetEnumDescription());
        }
    }

    public class OrganizationReadModelToOrganizationBriefDtoMapping : MapProfile<OrganizationReadModel, OrganizationBriefDto>
    {
        public OrganizationReadModelToOrganizationBriefDtoMapping()
        {
            ForMember(x => x.PositionCount, x => x.Positions != null ? x.Positions.Count() : 0);
            ForMember(x => x.OrganizationTypeTitle, x => x.OrganizationTypeId.GetEnumDescription());
        }
    }
}
