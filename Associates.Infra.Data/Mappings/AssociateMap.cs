using Associates.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Associates.Infra.Data.Mappings
{
    public class AssociateMap : IEntityTypeConfiguration<Associate>
    {
        public void Configure(EntityTypeBuilder<Associate> builder)
        {
            builder.Property(a => a.Id)
                .IsRequired();
        }
    }
}
