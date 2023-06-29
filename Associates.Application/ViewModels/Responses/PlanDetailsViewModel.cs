using Associates.Application.ViewModels.Enums;
using System.Text.Json.Serialization;

namespace Associates.Application.ViewModels.Responses
{
    public class PlanDetailsViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("numero_cartao_plano")]
        public string? PlanCardNumber { get; set; }

        [JsonIgnore]
        public DateTime PlanExpirationDate { get; set; }

        [JsonPropertyName("data_expiracao_plano")]
        public string FormattedPlanExpirationDate { get { return PlanExpirationDate.ToString("yyyy-MM-dd"); } }

        [JsonIgnore]
        public EPlanOptionViewModel PlanOption { get; set; }

        [JsonPropertyName("opcao_plano")]
        public string PlanOptionName
        {
            get { return PlanOption == EPlanOptionViewModel.MedicalPlan ? "Plano médico" : "Plano médico / odontológico"; }
        }

        [JsonIgnore]
        public EPlanClassificationViewModel PlanClassification { get; set; }

        [JsonPropertyName("classificacao_plano")]
        public string PlanClassificationName
        {
            get
            {
                return PlanClassification switch
                {
                    EPlanClassificationViewModel.Apartament => "Apartamento",
                    EPlanClassificationViewModel.Nursery => "Enfermagem",
                    EPlanClassificationViewModel.Vip => "VIP",
                    _ => string.Empty,
                };
            }
        }

        [JsonIgnore]
        public EPlanTypeViewModel PlanType { get; set; }

        [JsonPropertyName("tipo_plano")]
        public string PlanTypeName 
        { 
            get
            {
                return PlanType == EPlanTypeViewModel.Individual ? "Individual" : "Empresarial";
            }
        }

        [JsonIgnore]
        [JsonPropertyName("id_valores")]
        public int PlanPricingTableId { get; set; }

        [JsonPropertyName("valores")]
        public PlanPricingTableViewModel PlanPricingTable { get; set; }
    }
}
