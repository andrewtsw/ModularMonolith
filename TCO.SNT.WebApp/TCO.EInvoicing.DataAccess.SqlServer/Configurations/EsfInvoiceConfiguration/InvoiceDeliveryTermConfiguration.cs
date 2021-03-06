using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceDeliveryTermConfiguration : IEntityTypeConfiguration<InvoiceDeliveryTerm>
    {
        public void Configure(EntityTypeBuilder<InvoiceDeliveryTerm> builder)
        {
            builder.HasKey(x => x.InvoiceId);

            builder
                .HasOne(x => x.Invoice)
                .WithOne(i => i.DeliveryTerm)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.ContractDate)
                .HasColumnType("date");

            builder
                .Property(x => x.WarrantDate)
                .HasColumnType("date");
        }
    }
}
