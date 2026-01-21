using System.Text.Json.Serialization;


namespace Demographics.Application.ArcGis.Models
{
    public class ArcGisFeature
    {
        [JsonPropertyName("attributes")]
        public ArcGisAttributes Attributes { get; set; } = null!;
    }
}
