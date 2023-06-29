using Associates.Domain.Models;

namespace Associates.Domain.Interfaces
{
    public interface IPlanPricingRepository : IRepository<PlanPricingTable>
    {
        PlanPricingTable GetPlanPricing(int age, int planTypeId, int planOptionId, int planClassificationId);
    }
}
