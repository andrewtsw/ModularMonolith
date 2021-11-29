using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.Finportal.Framework.DataAccess.Configurations
{
    public class MeasureUnitConfiguration : IEntityTypeConfiguration<MeasureUnit>
    {
        public void Configure(EntityTypeBuilder<MeasureUnit> builder)
        {
            builder
                .HasIndex(x => x.Code)
                .IsUnique();
        }
    }
}
