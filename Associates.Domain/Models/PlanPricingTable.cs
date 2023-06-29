using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Associates.Domain.Models
{
    [Table(name: "PlanPricingTable", Schema = "dbo")]
    public class PlanPricingTable
    {
        [Key]
        [Column(name: "Id", TypeName = "int")]
        public int Id { get; set; }

        [Column(name: "AgeGroupStart", TypeName = "int")]
        public int AgeGroupStart { get; set; }

        [Column(name: "AgeGroupEnd", TypeName = "int")]
        public int AgeGroupEnd { get; set; }

        [Column(name: "PlanTypeId", TypeName = "int")]
        public int PlanTypeId { get; set; }

        [Column(name: "PlanOptionId", TypeName = "int")]
        public int PlanOptionId { get; set; }

        [Column(name: "PlanClassificationId", TypeName = "int")]
        public int PlanClassificationId { get; set; }

        [Column(name: "BasePrice", TypeName = "decimal")]
        public decimal BasePrice { get; set; }

        [Column(name: "FinalPrice", TypeName = "decimal")]
        public decimal FinalPrice { get; set; }
    }
}
