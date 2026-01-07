using Goldiran.Framework.Domain.Contracts;
using NgCrm.BasicInfoService.Domain.Locations.ReadModels;

namespace NgCrm.BasicInfoService.Domain.Locations.Contracts
{
    public interface ILocationQueryRepository : IQueryRepository<LocationReadModel>
    {
        Task<IList<LocationReadModel>> GetProvincesAsync(CancellationToken cancellationToken);
        Task<IList<LocationReadModel>> GetCitiesAsync(long provinceId, CancellationToken cancellationToken);
        Task<IList<LocationReadModel>> GetRegionsAsync(long cityId, CancellationToken cancellationToken);
    }
}
