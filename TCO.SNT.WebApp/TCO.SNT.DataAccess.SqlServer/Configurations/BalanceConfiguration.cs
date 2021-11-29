using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class BalanceConfiguration : IEntityTypeConfiguration<Balance>
    {
        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.Property(r => r.Quantity)
                .HasColumnType("decimal(18,6)");

            builder.Property(r => r.ReserveQuantity)
                .HasColumnType("decimal(18,6)");

            builder.HasOne(x => x.TaxpayerStore)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.MeasureUnit)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.ProductId);

            builder.HasIndex(x => x.Name);

            builder.HasIndex(x => x.KpvedCode);
            builder.HasIndex(x => x.TnvedCode);
            builder.HasIndex(x => x.GtinCode);

            builder.HasIndex(x => x.UnitPrice);
            builder.HasIndex(x => x.Quantity);
            builder.HasIndex(x => x.ReserveQuantity);
        }
    }
}
