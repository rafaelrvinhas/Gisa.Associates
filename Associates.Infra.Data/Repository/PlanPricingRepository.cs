using Associates.Domain.Interfaces;
using Associates.Domain.Models;
using Associates.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Associates.Infra.Data.Repository
{
    public class PlanPricingRepository : Repository<PlanPricingTable>, IPlanPricingRepository
    {
        public PlanPricingRepository(AssociateContext context) : base(context)
        { }

        public PlanPricingTable GetPlanPricing(int age, int planTypeId, int planOptionId, int planClassificationId)
        {
            return DbSet.AsNoTracking().FirstOrDefault(p => 
                p.PlanTypeId == planTypeId && 
                p.PlanOptionId == planOptionId && 
                p.PlanClassificationId == planClassificationId &&
                p.AgeGroupStart <= age &&
                p.AgeGroupEnd >= age);
        }
    }
}
