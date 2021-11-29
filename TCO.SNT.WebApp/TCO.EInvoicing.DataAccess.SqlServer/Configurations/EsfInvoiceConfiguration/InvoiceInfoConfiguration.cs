using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceInfoConfiguration : IEntityTypeConfiguration<InvoiceInfo>
    {
        public void Configure(EntityTypeBuilder<InvoiceInfo> builder)
        {
            builder.HasKey(x => x.InvoiceId);

            builder
                .HasOne(x => x.Invoice)
                .WithOne(i => i.InvoiceInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            // Unique index for not null values
            builder
                .HasIndex(x => x.RegistrationNumber)
                .IsUnique();

            builder.HasIndex(x => x.InvoiceStatus);
        }
    }
}
