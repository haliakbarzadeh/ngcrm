using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;
using NgCrm.BasicInfoService.Domain.Permissions.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Permissions.Queries
{
    public class GetPermissionByWorkspaceIdQuery : BaseQueryRequest, IRequest<IEnumerable<PermissionBriefDto>>
    {
        public long WorkspaceId { get; set; }
    }
}
