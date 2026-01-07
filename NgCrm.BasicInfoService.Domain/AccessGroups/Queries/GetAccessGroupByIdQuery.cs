using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Queries
{
    public class GetAccessGroupByIdQuery : BaseQueryRequest, IRequest<AccessGroupDetailDto>
    {
        public long Id { get; set; }
    }
}
