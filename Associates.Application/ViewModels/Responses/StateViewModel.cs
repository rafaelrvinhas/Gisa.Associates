using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Responses
{
    public class StateViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("nome")]
        public string? Name { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }
    }
}
