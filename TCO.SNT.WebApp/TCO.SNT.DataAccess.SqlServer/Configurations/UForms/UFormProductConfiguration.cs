using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class UFormProductConfiguration : IEntityTypeConfiguration<UFormProduct>
    {
        public void Configure(EntityTypeBuilder<UFormProduct> builder)
        {
            builder
                .HasOne(p => p.MeasureUnit)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Product)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Balance)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(r => r.Quantity)
                .HasColumnType("decimal(18,6)");
        }
    }
}
