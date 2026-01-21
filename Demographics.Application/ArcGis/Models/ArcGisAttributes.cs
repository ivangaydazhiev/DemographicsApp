using System.Text.Json.Serialization;


namespace Demographics.Application.ArcGis.Models
{
    public class ArcGisAttributes
    {
        [JsonPropertyName("state_name")]
        public string StateName { get; set; } = string.Empty;

        [JsonPropertyName("population")]
        public  long? Population { get; set; }
    }
}
