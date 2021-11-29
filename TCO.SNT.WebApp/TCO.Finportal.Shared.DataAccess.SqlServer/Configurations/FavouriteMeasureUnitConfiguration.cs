using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.Finportal.Shared.Entities;

namespace TCO.Finportal.Shared.DataAccess.SqlServer.Configurations
{
    public class FavouriteMeasureUnitConfiguration : IEntityTypeConfiguration<FavouriteMeasureUnit>
    {
        public void Configure(EntityTypeBuilder<FavouriteMeasureUnit> builder)
        {
            builder
               .HasKey(x => x.MeasureUnitId);

            builder.HasOne(x => x.MeasureUnit)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
