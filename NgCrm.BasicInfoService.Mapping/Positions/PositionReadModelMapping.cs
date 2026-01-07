using Goldiran.Framework.Application.Helpers;
using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.ReadModels;

namespace NgCrm.BasicInfoService.Mapping.Positions
{
    public class PositionReadModelMapping : MapProfile<PositionReadModel, PositionDto>
    {
        public PositionReadModelMapping()
        {
            ForMember(x => x.OrganizationTitle, x => x.Organization.Title);
            ForMember(x => x.WorkspaceTitle, x => x.Workspace.Title);
            ForMember(x => x.PositionPermissionDtos, x => x.PositionPermissions);
            ForMember(x => x.PositionTypeTitle, x => x.PositionTypeId.GetEnumDescription());
        }
    }

    public class PositionReadModelToPositionBriefDtoMapping : MapProfile<PositionReadModel, PositionBriefDto>
    {
        public PositionReadModelToPositionBriefDtoMapping()
        {
            ForMember(x => x.OrganizationTitle, x => x.Organization.Title);
            ForMember(x => x.WorkspaceTitle, x => x.Workspace.Title);
            ForMember(x => x.PositionTypeTitle, x => x.PositionTypeId.GetEnumDescription());
        }
    }
}
