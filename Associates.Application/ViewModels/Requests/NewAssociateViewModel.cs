using Associates.Application.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Requests
{
    /// <summary>
    /// Contém os dados da requisição de inclusão de um novo associado
    /// </summary>
    public class NewAssociateViewModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public NewAssociateViewModel()
        {
            Name = string.Empty;
            Email = string.Empty;
            DocumentNumber = string.Empty;
            Address = new AddressViewModel();
            Plan = new PlanViewModel();
        }

        /// <summary>
        /// Nome do novo associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o nome do novo associado.")]
        [StringLength(250)]
        [JsonPropertyName("nome")]
        public string Name { get; set; }

        /// <summary>
        /// Email do novo associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o e-mail do novo associado.")]
        [StringLength(100)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Número do CPF do novo associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o CPF do novo associado.")]
        [StringLength(11)]
        [JsonPropertyName("cpf")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Data de nascimento do novo associado
        /// </summary>
        [Required(ErrorMessage = "Por favor, informe a data de nascimento do novo associado.")]
        [JsonPropertyName("data_nascimento")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Gênero do novo associado. 1 - Masculino / 2 - Feminino / 3 - Não informado
        /// </summary>
        [Required(ErrorMessage = "Por favor, selecione umas das opções do campo 'gênero'.")]
        [JsonPropertyName("genero")]
        public EGenderViewModel Gender { get; set; }

        /// <summary>
        /// Informações de endereço do novo associado
        /// </summary>
        [JsonPropertyName("endereco")]
        public AddressViewModel Address { get; set; }

        /// <summary>
        /// Informações do plano do novo associado
        /// </summary>
        [JsonPropertyName("plano")]
        public PlanViewModel Plan { get; set; }
    }
}
