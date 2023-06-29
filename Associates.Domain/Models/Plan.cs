using Associates.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Associates.Domain.Models
{
    [Table(name: "Plan", Schema = "dbo")]
    public class Plan
    {
        public Plan()
        {
            PlanCardNumber = string.Empty;
            PlanPricingTable = new PlanPricingTable();
        }

        public Plan(
            DateTime planExpirationDate,
            EPlanOption planOption,
            EPlanClassification planClassification,
            EPlanType planType, 
            int planPricingTableId, 
            int consultationsConveredPerYear,
            int examsCoveredPerYear)
        {
            PlanCardNumber = GeneratePlanCardNumber();
            PlanExpirationDate = planExpirationDate;
            PlanOption = planOption;
            PlanClassification = planClassification;
            PlanType = planType;
            PlanPricingTableId = planPricingTableId;
            ConsultationsConveredPerYear = consultationsConveredPerYear;
            ExamsCoveredPerYear = examsCoveredPerYear;
        }

        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "PlanCardNumber", TypeName = "varchar(50)")]
        public string PlanCardNumber { get; set; }

        [Column(name: "PlanExpirationDate", TypeName = "datetime")]
        public DateTime PlanExpirationDate { get; set; }

        [Column(name: "PlanOptionId", TypeName = "int")]
        public EPlanOption PlanOption { get; set; }

        [Column(name: "PlanClassificationId", TypeName = "int")]
        public EPlanClassification PlanClassification { get; set; }

        [Column(name: "PlanTypeId", TypeName = "int")]
        public EPlanType PlanType { get; set; }

        [Column(name: "ConsultationsConveredPerYear", TypeName = "int")]
        public int ConsultationsConveredPerYear { get; set; }

        [Column(name: "ExamsCoveredPerYear", TypeName = "int")]
        public int ExamsCoveredPerYear { get; set; }

        [ForeignKey("PlanPricingTableId")]
        [Column(name: "PlanPricingTableId", TypeName = "int")]
        public int PlanPricingTableId { get; set; }
        public PlanPricingTable PlanPricingTable { get; set; }

        private static string GeneratePlanCardNumber()
        {
            return new Random().NextInt64(0, long.MaxValue).ToString();
        }
    }
}
