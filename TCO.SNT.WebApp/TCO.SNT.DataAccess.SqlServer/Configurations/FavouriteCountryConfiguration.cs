

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class FavouriteCountryConfiguration : IEntityTypeConfiguration<FavouriteCountry>
    {
        public void Configure(EntityTypeBuilder<FavouriteCountry> builder)
        {
            builder.ToTable("FavouriteCountries");

            builder.HasKey(b => b.CountryId);

            builder.HasOne(b => b.Country)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
