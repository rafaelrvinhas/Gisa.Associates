using Associates.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Associates.Application.ViewModels.Requests
{
    /// <summary>
    /// Contém os dados do associado a ser atualizado
    /// </summary>
    public class UpdateAssociateDataViewModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public UpdateAssociateDataViewModel()
        {
            Email = string.Empty;
            Address = new AddressViewModel();
        }

        /// <summary>
        /// Email do novo associado
        /// </summary>
        [StringLength(100)]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// Data de nascimento do novo associado
        /// </summary>
        [JsonPropertyName("data_nascimento")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Gênero do novo associado. 1 - Masculino / 2 - Feminino / 3 - Não informado
        /// </summary>
        [JsonPropertyName("genero")]
        public EGenderViewModel Gender { get; set; }

        /// <summary>
        /// Informações de endereço do novo associado
        /// </summary>
        [JsonPropertyName("endereco")]
        public AddressViewModel Address { get; set; }
    }
}
