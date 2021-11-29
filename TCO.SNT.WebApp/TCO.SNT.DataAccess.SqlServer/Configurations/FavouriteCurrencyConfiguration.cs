using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class FavouriteCurrencyConfiguration : IEntityTypeConfiguration<FavouriteCurrency>
    {
        public void Configure(EntityTypeBuilder<FavouriteCurrency> builder)
        {

            builder.ToTable("FavouriteCurrencies");

            builder.HasKey(b => b.CurrencyId);

            builder.HasOne(o => o.Currency)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
