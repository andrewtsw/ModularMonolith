﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.EsfInvoiceConfiguration
{
    public class InvoiceConsignorConfiguration : IEntityTypeConfiguration<InvoiceConsignor>
    {
        public void Configure(EntityTypeBuilder<InvoiceConsignor> builder)
        {
            builder.HasKey(x => x.InvoiceId);

            builder
                .HasOne(x => x.Invoice)
                .WithOne(i => i.Consignor)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
