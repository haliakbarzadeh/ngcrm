using Goldiran.Framework.EFCore.Repositories;
using NgCrm.BasicInfoService.Domain.Positions.Contracts;
using NgCrm.BasicInfoService.Domain.Positions.Entities;

namespace NgCrm.BasicInfoService.DataAccess.Command.Positions
{
    public class PositionCommandRepository : CommandRepository<Position, BasicInfoCommandContext>, IPositionCommandRepository
    {
        public PositionCommandRepository(BasicInfoCommandContext dbContext) : base(dbContext)
        {
        }
    }
}
