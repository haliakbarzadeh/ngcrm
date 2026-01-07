using NgCrm.BasicInfoService.Proxy.AD.Models;
using NgCrm.BasicInfoService.Proxy.Map.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgCrm.BasicInfoService.Proxy.Map.Contracts
{
    public interface IMapDataProxy
    {
        Task<IEnumerable<ProvinceModel>> GetAllProvincesAsync();

        Task<IEnumerable<CityModel>> GetCitiesByProvinceIdAsync(long provinceId);

        Task<ReverseGeocodeResponseApiModel> ReverseGeocodeAsync(GeocodeRequestModel geocodeRequestModel);

        Task<SearchResponseModel> SearchAsync(SearchRequestModel searchRequestModel);

    }
}
