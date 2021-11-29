using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoicePublicOfficeConfiguration : IEntityTypeConfiguration<InvoicePublicOffice>
    {
        public void Configure(EntityTypeBuilder<InvoicePublicOffice> builder)
        {
            builder.HasKey(x => x.InvoiceId);

            builder
                .HasOne(x => x.Invoice)
                .WithOne(i => i.PublicOffice)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
