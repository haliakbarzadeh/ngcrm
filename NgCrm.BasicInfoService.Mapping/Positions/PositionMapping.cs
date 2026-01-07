using Goldiran.Framework.Mapping.Mapster;
using NgCrm.BasicInfoService.Domain.Positions.Dtos;
using NgCrm.BasicInfoService.Domain.Positions.Entities;

namespace NgCrm.BasicInfoService.Mapping.Positions
{
    public class PositionMapping : MapProfile<Position, PositionDto>
    {
        public PositionMapping()
        {
            //ForMember(x => x.Id, x => x.Id);
        }
    }
}
