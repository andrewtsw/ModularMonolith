using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class RelatedInvoiceConfiguration : IEntityTypeConfiguration<RelatedInvoice>
    {
        public void Configure(EntityTypeBuilder<RelatedInvoice> builder)
        {
            builder.HasKey(x => x.InvoiceId);

            builder
                .HasOne(x => x.Invoice)
                .WithOne(i => i.RelatedInvoice)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Date)
                .HasColumnType("date");
        }
    }
}
