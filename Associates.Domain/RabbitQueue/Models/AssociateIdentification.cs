namespace Associates.Domain.RabbitQueue.Models
{
    public class AssociateIdentification
    {
        public AssociateIdentification(int associateId, string email, string documentNumber, int associateCategoryId, int planId)
        {
            AssociateId = associateId;
            Email = email;
            DocumentNumber = documentNumber;
            AssociateCategoryId = associateCategoryId;
            PlanId = planId;
        }

        public int AssociateId { get; set; }
        public string Email { get; set; }
        public string DocumentNumber{ get; set; }
        public int AssociateCategoryId { get; set; }
        public int PlanId { get; set; }
    }
}
