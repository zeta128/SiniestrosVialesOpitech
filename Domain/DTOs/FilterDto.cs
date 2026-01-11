using System.Text.Json.Serialization;

namespace SiniestrosVialesOpitech.Domain.DTOs
{
    public class FilterDto
    {
        [JsonPropertyName("text")]
        public string FieldFilter { get; set; } = string.Empty;

        [JsonPropertyName("value")]
        public string ValueFilter { get; set; } = string.Empty;
    }
}
