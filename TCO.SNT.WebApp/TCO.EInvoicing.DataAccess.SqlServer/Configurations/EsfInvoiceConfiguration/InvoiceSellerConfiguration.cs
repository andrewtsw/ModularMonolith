using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;
using TCO.Finportal.Framework.DataAccess;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceSellerConfiguration : IEntityTypeConfiguration<InvoiceSeller>
    {
        public void Configure(EntityTypeBuilder<InvoiceSeller> builder)
        {
            builder
                .HasOne(x => x.Invoice)
                .WithMany(i => i.Sellers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Statuses)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasConversion(EntityTypeConfigurationHelper.BuildValueConverter<InvoiceSellerType>())
                    .Metadata
                    .SetValueComparer(EntityTypeConfigurationHelper.BuildValueComparer<InvoiceSellerType>());
        }
    }
}
