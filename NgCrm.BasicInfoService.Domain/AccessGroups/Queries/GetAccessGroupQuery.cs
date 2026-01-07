using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.AccessGroups.Dtos;

namespace NgCrm.BasicInfoService.Domain.AccessGroups.Queries
{
    public class GetAccessGroupQuery : BaseQueryRequest, IRequest<Paged<AccessGroupBriefDto>>
    {
        public string SearchTerm { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
    }
}
