using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Responses
{
    public class AddressDetailsViewModel
    {
        public AddressDetailsViewModel()
        {
            State = new StateViewModel();
        }

        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("logradouro")]
        public string? StreetName { get; set; }

        [JsonPropertyName("numero")]
        public string? Number { get; set; }

        private string _complement;

        [JsonPropertyName("complemento")]
        public string Complement 
        {
            get { return string.IsNullOrEmpty(_complement) ? "N/A" : _complement; }
            set { _complement = value; }
        }

        [JsonPropertyName("cep")]
        public string? ZipCode { get; set; }

        [JsonPropertyName("bairro")]
        public string? Neighborhood { get; set; }

        [JsonPropertyName("cidade")]
        public string? City { get; set; }

        [JsonIgnore]
        public int StateId { get; set; }

        [JsonPropertyName("estado")]
        public StateViewModel State { get; set; }
    }
}
