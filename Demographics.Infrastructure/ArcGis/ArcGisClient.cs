using Demographics.Application.Interfaces;
using Demographics.Application.ArcGis.Models;
using System.Net.Http.Json;


namespace Demographics.Infrastructure.ArcGis
{
    public class ArcGisClient : IArcGisClient
    {
        private const string Url =
            "https://services.arcgis.com/P3ePLMYs2RVChkJx/ArcGIS/rest/services/" +
            "USA_Census_Counties/FeatureServer/0/query" +
             "?where=1%3D1&outFields=population,state_name&returnGeometry=false&f=json";

        private readonly HttpClient _httpClient;

        public ArcGisClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ArcGisAttributes>> GetCountyDemographicsAsync(
            CancellationToken cancellationToken = default)
        { 

        
            var response = await _httpClient
                .GetFromJsonAsync<ArcGisResponse>(Url, cancellationToken);

            return response?.Features
                .Select(f => f.Attributes)
                .Where(a => !string.IsNullOrWhiteSpace(a.StateName))
                .ToList()
                ?? new List<ArcGisAttributes>();
        }

    }
}
