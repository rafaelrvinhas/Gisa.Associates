using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Requests
{
    /// <summary>
    /// Contém as informações de endereço do associado
    /// </summary>
    public class AddressViewModel
    {
        /// <summary>
        /// Logradouro do endereço residencial do associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o logradouro da residência.")]
        [StringLength(250)]
        [JsonPropertyName("logradouro")]
        public string? StreetName { get; set; }

        /// <summary>
        /// Número da residência do associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o número da residência.")]
        [StringLength(10)]
        [JsonPropertyName("numero")]
        public string? Number { get; set; }

        /// <summary>
        /// Complemento do endereço do associado
        /// </summary>
        [StringLength(250)]
        [JsonPropertyName("complemento")]
        public string? Complement { get; set; }

        /// <summary>
        /// Número do CEP
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o CEP da residência.")]
        [StringLength(8)]
        [JsonPropertyName("cep")]
        public string? ZipCode { get; set; }

        /// <summary>
        /// Bairro da residência do associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o bairro da residência.")]
        [StringLength(250)]
        [JsonPropertyName("bairro")]
        public string? Neighborhood { get; set; }

        /// <summary>
        /// Cidade da residência do associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe a cidade em que o novo associado reside.")]
        [StringLength(250)]
        [JsonPropertyName("cidade")]
        public string? City { get; set; }

        /// <summary>
        /// UF da residência do associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, selecione uma UF.")]
        [JsonPropertyName("id_estado")]
        public int StateId { get; set; }
    }
}
