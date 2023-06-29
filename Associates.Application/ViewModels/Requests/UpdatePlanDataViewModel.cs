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
    /// Contém os dados do plano a ser atualizado
    /// </summary>
    public class UpdatePlanDataViewModel
    {
        /// <summary>
        /// Tipo do plano: 1 - Individual / 2 - Empresarial
        /// </summary>
        [JsonPropertyName("tipo_plano")]
        public EPlanTypeViewModel PlanType { get; set; }

        /// <summary>
        /// Opção do plano: 1 - Plano médico / 2 - Plano médico odontológico
        /// </summary>
        [JsonPropertyName("opcao_plano")]
        public EPlanOptionViewModel PlanOption { get; set; }

        /// <summary>
        /// Classificação do plano: 1 - Enfermaria / 2 - Apartamento / 3 - VIP
        /// </summary>
        [JsonPropertyName("classificacao_plano")]
        public EPlanClassificationViewModel PlanClassification { get; set; }

        /// <summary>
        /// Quantidade de consultas com cobertura por ano
        /// </summary>
        [JsonPropertyName("num_consultas_ano")]
        public int ConsultationsConveredPerYear { get; set; }

        /// <summary>
        /// Quantidade de exames com cobertura por ano
        /// </summary>
        [JsonPropertyName("num_exames_ano")]
        public int ExamsCoveredPerYear { get; set; }
    }
}
