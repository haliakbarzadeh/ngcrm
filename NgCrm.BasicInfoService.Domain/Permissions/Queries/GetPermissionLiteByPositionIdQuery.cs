using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Permissions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Permissions.Queries
{
    public class GetPermissionLiteByPositionIdQuery : BaseQueryRequest, IRequest<IEnumerable<PermissionLiteDto>>
    {
        public long PositionId { get; set; }
    }
}
