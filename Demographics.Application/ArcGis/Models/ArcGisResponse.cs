using System.Text.Json.Serialization;


namespace Demographics.Application.ArcGis.Models
{
    public class ArcGisResponse
    {
        [JsonPropertyName("features")]
        public List<ArcGisFeature> Features { get; set; } = new();
    }
}
