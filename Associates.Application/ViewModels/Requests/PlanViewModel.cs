using Associates.Application.ViewModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Requests
{
    /// <summary>
    /// Contém as informações do plano de saúde do associado
    /// </summary>
    public class PlanViewModel
    {
        /// <summary>
        /// Tipo do plano: 1 - Individual / 2 - Empresarial
        /// </summary>
        [Required(ErrorMessage = "Por favor, selecione um tipo de plano: 1 - Individual / 2 - Empresarial")]
        [JsonPropertyName("tipo_plano")]
        public EPlanTypeViewModel PlanType { get; set; }

        /// <summary>
        /// Opção do plano: 1 - Plano médico / 2 - Plano médico odontológico
        /// </summary>
        [Required(ErrorMessage = "Por favor, selecione uma opção de plano: 1 - Plano médico / 2 - Plano médico odontológico")]
        [JsonPropertyName("opcao_plano")]
        public EPlanOptionViewModel PlanOption { get; set; }

        /// <summary>
        /// Classificação do plano: 1 - Enfermaria / 2 - Apartamento / 3 - VIP
        /// </summary>
        [Required(ErrorMessage = "Por favor, selecione uma classificação de plano: 1 - Enfermaria / 2 - Apartamento / 3 - VIP")]
        [JsonPropertyName("classificacao_plano")]
        public EPlanClassificationViewModel PlanClassification { get; set; }

        /// <summary>
        /// Quantidade de consultas com cobertura por ano
        /// </summary>
        [Required(ErrorMessage = "Por favor, informe a quantidade de consultas com cobertura por ano.")]
        [JsonPropertyName("num_consultas_ano")]
        public int ConsultationsConveredPerYear { get; set; }

        /// <summary>
        /// Quantidade de exames com cobertura por ano
        /// </summary>
        [Required(ErrorMessage = "Por favor, informe a quantidade de exames com cobertura por ano.")]
        [JsonPropertyName("num_exames_ano")]
        public int ExamsCoveredPerYear { get; set; }
    }
}
