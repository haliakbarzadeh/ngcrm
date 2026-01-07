using Goldiran.Framework.Application.Queries;
using MediatR;

namespace NgCrm.BasicInfoService.Domain.Users.Queries
{
    public class GetUserPermissionHistoryQuery : BaseQueryRequest, IRequest<IEnumerable<long>>
    {
        public long UserId { get; set; }
        public DateTime TargetDate { get; set; } = DateTime.Now;
    }
}