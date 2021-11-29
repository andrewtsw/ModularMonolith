using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceProductConfiguration : IEntityTypeConfiguration<InvoiceProduct>
    {
        public void Configure(EntityTypeBuilder<InvoiceProduct> builder)
        {
            builder
                .HasOne(x => x.Invoice)
                .WithMany(i => i.Products)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(r => r.Quantity)
                .HasColumnType("decimal(18,6)");
        }
    }
}
