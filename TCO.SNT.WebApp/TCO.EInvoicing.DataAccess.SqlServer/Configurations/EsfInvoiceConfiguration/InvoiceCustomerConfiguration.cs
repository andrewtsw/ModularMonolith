using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;
using TCO.Finportal.Framework.DataAccess;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceCustomerConfiguration : IEntityTypeConfiguration<InvoiceCustomer>
    {
        public void Configure(EntityTypeBuilder<InvoiceCustomer> builder)
        {
            builder
                .HasOne(x => x.Invoice)
                .WithMany(i => i.Customers)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Statuses)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasConversion(EntityTypeConfigurationHelper.BuildValueConverter<InvoiceCustomerType>())
                    .Metadata
                    .SetValueComparer(EntityTypeConfigurationHelper.BuildValueComparer<InvoiceCustomerType>());
        }
    }
}
