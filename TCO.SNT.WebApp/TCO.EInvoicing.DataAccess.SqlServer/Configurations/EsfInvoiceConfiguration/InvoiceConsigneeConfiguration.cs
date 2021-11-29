using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceConsigneeConfiguration : IEntityTypeConfiguration<InvoiceConsignee>
    {
        public void Configure(EntityTypeBuilder<InvoiceConsignee> builder)
        {
            builder.HasKey(x => x.InvoiceId);

            builder
                .HasOne(x => x.Invoice)
                .WithOne(i => i.Consignee)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
