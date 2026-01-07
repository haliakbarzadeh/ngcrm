using Goldiran.Framework.Application.Queries;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Positions.Queries
{
    public class GetPositionPermissionHistoryQuery : BaseQueryRequest, IRequest<IEnumerable<long>>
    {
        public long PositionId { get; set; }
        public DateTime TargetDate { get; set; } = DateTime.Now;
    }
}
