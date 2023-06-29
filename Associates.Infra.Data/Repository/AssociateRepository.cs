using Associates.Domain.Interfaces;
using Associates.Domain.Models;
using Associates.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Associates.Infra.Data.Repository
{
    public class AssociateRepository : Repository<Associate>, IAssociateRepository
    {
        public AssociateRepository(AssociateContext context) : base(context)
        { }

        public async Task<Associate> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(a => a.Email == email);
        }

        public Associate GetByDocumentNumber(string documentNumber)
        {
            return DbSet.AsNoTracking()
                .Where(a => a.DocumentNumber == documentNumber)
                .Include(a => a.Address)
                .Include(a => a.Address.State)
                .Include(a => a.Plan)
                .Include(a => a.Plan.PlanPricingTable)
                .FirstOrDefault();
        }
    }
}
