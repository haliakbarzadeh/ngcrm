using Goldiran.Framework.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using NgCrm.BasicInfoService.Domain.Locations.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.Enums;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.DataAccess.Query.Locations
{
    public class LocationQueryRepository : QueryRepository<LocationReadModel, BasicInfoQueryContext>, ILocationQueryRepository
    {
        public LocationQueryRepository(BasicInfoQueryContext dbContext) : base(dbContext)
        {

        }


        public async Task<IList<LocationReadModel>> GetCitiesAsync(long provinceId, CancellationToken cancellationToken)
        {
            return await EntitySet.Where(x => x.ParentId == provinceId).ToListAsync(cancellationToken);
        }

        public async Task<IList<LocationReadModel>> GetProvincesAsync(CancellationToken cancellationToken)
        {
            return await EntitySet.Where(x => x.LocationTypeId == (int)LocationTypes.Province).ToListAsync(cancellationToken);
        }

        public async Task<IList<LocationReadModel>> GetRegionsAsync(long cityId, CancellationToken cancellationToken)
        {
            return await EntitySet.Where(x => x.ParentId == cityId).ToListAsync(cancellationToken);
        }
    }
}
