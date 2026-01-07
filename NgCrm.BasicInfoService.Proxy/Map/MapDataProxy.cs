using Mapster;
using Microsoft.Extensions.Options;
using NgCrm.BasicInfoService.Domain.Common.Models;
using NgCrm.BasicInfoService.Proxy.Map.Contracts;
using NgCrm.BasicInfoService.Proxy.Map.Models;
using System.Net.Http.Json;


public class MapDataProxy : IMapDataProxy
{
    private readonly HttpClient _httpClient;
    private readonly AppSetting _appSetting;
    public MapDataProxy(HttpClient httpClient, IOptions<AppSetting> options)
    {
        _httpClient = httpClient;
        _appSetting = options.Value;
    }

    public async Task<IEnumerable<ProvinceModel>> GetAllProvincesAsync()
    {
        var url = _appSetting.MapConfig.GetAllProvinces;
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Api-Key", _appSetting.MapConfig.ApiKey);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<List<ProvinceModel>>();
        return result ?? Enumerable.Empty<ProvinceModel>();
    }

    public async Task<IEnumerable<CityModel>> GetCitiesByProvinceIdAsync(long provinceId)
    {
        var url = _appSetting.MapConfig.GetCitiesByProvinceId.Replace("{provinceId}", provinceId.ToString());
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Api-Key", _appSetting.MapConfig.ApiKey);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<List<CityModel>>();
        return result ?? Enumerable.Empty<CityModel>();
    }

    public async Task<ReverseGeocodeResponseApiModel> ReverseGeocodeAsync(GeocodeRequestModel geocodeRequestModel)
    {
        var url = _appSetting.MapConfig.ReverseGeocode
            .Replace("{lat}", geocodeRequestModel.Lat.ToString())
            .Replace("{lng}", geocodeRequestModel.Lng.ToString());

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Api-Key", _appSetting.MapConfig.ApiKey);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ReverseGeocodeResultModel>();

        return result.Adapt<ReverseGeocodeResponseApiModel>();

    }

    public async Task<SearchResponseModel> SearchAsync(SearchRequestModel searchRequestModel)
    {
        var url = _appSetting.MapConfig.Search.Replace("{term}", searchRequestModel.Term)
                                            .Replace("{lat}", searchRequestModel.Lat.ToString())
                                            .Replace("{lng}", searchRequestModel.Lng.ToString());

        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Api-Key", _appSetting.MapConfig.ApiKey);

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<SearchResponseModel>();

    }
}

