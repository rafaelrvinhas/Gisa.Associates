using Associates.Domain.Models;

namespace Associates.Domain.Interfaces
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Plan Add(Plan plan);
    }
}
