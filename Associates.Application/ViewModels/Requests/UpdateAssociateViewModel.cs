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
    /// Contém os dados para a requisição de uma atualização de um associado
    /// </summary>
    public class UpdateAssociateViewModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public UpdateAssociateViewModel()
        {
            DocumentNumber = string.Empty;
            UpdateAssociateData = new UpdateAssociateDataViewModel();
        }

        /// <summary>
        /// Número do CPF do novo associado
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor, informe o CPF do novo associado.")]
        [StringLength(11)]
        [JsonPropertyName("cpf")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Dados do associado a serem atualizados
        /// </summary>
        [JsonPropertyName("novos_dados")]
        public UpdateAssociateDataViewModel UpdateAssociateData { get; set; }
    }
}
