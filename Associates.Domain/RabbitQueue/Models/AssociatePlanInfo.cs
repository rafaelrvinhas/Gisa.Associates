namespace Associates.Domain.RabbitQueue.Models
{
    public class AssociatePlanInfo
    {
        public AssociatePlanInfo(int associateId, int planId, int planClassificationId, int planOptionId, int planTypeId, string planExpirationDate)
        {
            AssociateId = associateId;
            PlanId = planId;
            PlanClassificationId = planClassificationId;
            PlanOptionId = planOptionId;
            PlanTypeId = planTypeId;
            PlanExpirationDate = planExpirationDate;
        }

        public int AssociateId { get; set; }
        public int PlanId { get; set; }
        public int PlanClassificationId { get; set; }
        public int PlanOptionId { get; set; }
        public int PlanTypeId { get; set; }
        public string PlanExpirationDate { get; set; }
    }
}
