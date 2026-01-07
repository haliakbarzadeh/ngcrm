using Goldiran.Framework.Application.Queries;
using MediatR;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;

namespace NgCrm.BasicInfoService.Domain.Positions.Queries
{
    public class GetPositionByIdQuery : BaseQueryRequest, IRequest<PositionDto>
    {
        public long Id { get; set; }
    }

}
