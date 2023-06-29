using Associates.Domain.Interfaces;
using Associates.Domain.Models;
using Associates.Infra.Data.Context;

namespace Associates.Infra.Data.Repository
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        public PlanRepository(AssociateContext context) : base(context)
        { }

        public Plan Add(Plan plan)
        {
            DbSet.Add(plan);
            Db.SaveChanges();

            return plan;
        }
    }
}
