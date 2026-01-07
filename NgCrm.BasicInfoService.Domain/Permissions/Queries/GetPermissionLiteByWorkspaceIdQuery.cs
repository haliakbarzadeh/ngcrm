using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Permissions.Queries
{
    public class GetPermissionLiteByWorkspaceIdQuery : BaseQueryRequest, IRequest<IEnumerable<PermissionLiteDto>>
    {
        public long WorkspaceId { get; set; }
    }
}
