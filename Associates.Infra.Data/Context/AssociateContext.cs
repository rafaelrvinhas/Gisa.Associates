using Associates.Domain.Models;
using Associates.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Associates.Infra.Data.Context
{
    public class AssociateContext : DbContext
    {
        public AssociateContext(DbContextOptions<AssociateContext> options) : base(options) { }

        public DbSet<Associate> Associates { get; set; }
        public DbSet<PlanPricingTable> PlanPricings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Associate>().ToTable("Associate");
            modelBuilder.Entity<PlanPricingTable>().ToTable("PlanPricingTable");
            modelBuilder.Entity<Plan>().ToTable("Plan");

            modelBuilder.ApplyConfiguration(new AssociateMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
