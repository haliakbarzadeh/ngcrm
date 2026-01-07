using Goldiran.Framework.Application.Queries;
using Goldiran.Framework.Domain.Models;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Enums;

namespace NgCrm.BasicInfoService.Domain.Positions.Queries
{
    public class GetPositionQuery : BaseQueryRequest, IRequest<Paged<PositionBriefDto>>
    {
        public string Title { get; set; }
        public ICollection<long>? OrganizationIds { get; set; }
        public ICollection<long>? WorkspaceIds { get; set; }
        public bool? IsActive { get; set; }
        public ICollection<PositionTypes>? PositionTypeIds { get; set; }
    }
}
