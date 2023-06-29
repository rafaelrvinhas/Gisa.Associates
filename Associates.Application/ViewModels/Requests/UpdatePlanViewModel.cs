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
    /// Contém as informações de associado e plano necessárias para realizar uma atualização de plano
    /// </summary>
    public class UpdatePlanViewModel
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public UpdatePlanViewModel()
        {
            AssociateDocumentNumber = string.Empty;
            UpdatePlanData = new UpdatePlanDataViewModel();
        }

        /// <summary>
        /// Número de documento do associado titular do plano
        /// </summary>
        [Required(ErrorMessage = "Por favor, informe o CPF do associado titular do plano.")]
        public string AssociateDocumentNumber { get; set; }

        /// <summary>
        /// Dados do plano a serem atualizados
        /// </summary>
        public UpdatePlanDataViewModel UpdatePlanData { get; set; }
    }
}
