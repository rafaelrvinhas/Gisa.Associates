using Associates.Domain.Models.Enums;
using Associates.Domain.Core.Commands;

namespace Associates.Domain.Commands
{
    public abstract class AssociateCommand : Command
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public EGender Gender { get; set; }
        public EAssociateCategory AssociateCategory { get; set; }
        public string? StreetName { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? ZipCode { get; set; }
        public string? Neighborhood { get; set; }
        public string? City { get; set; }
        public int StateId { get; set; }
        public EPlanType PlanType { get; set; }
        public EPlanOption PlanOption { get; set; }
        public EPlanClassification PlanClassification { get; set; }
        public int ConsultationsConveredPerYear { get; set; }
        public int ExamsCoveredPerYear { get; set; }
    }
}
