using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder
                .Property(x => x.Date)
                .HasColumnType("date");

            builder
                .Property(x => x.TurnoverDate)
                .HasColumnType("date");

            builder
                .Property(x => x.DeliveryDocDate)
                .HasColumnType("date");

            builder
                .Property(x => x.DatePaper)
                .HasColumnType("date");

            // Unique index for not null values
            builder
                .HasIndex(x => x.ExternalId)
                .IsUnique();
        }
    }
}
