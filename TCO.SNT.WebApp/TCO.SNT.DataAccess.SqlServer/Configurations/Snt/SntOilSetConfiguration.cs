using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntOilSetConfiguration : IEntityTypeConfiguration<SntOilSet>
    {
        public void Configure(EntityTypeBuilder<SntOilSet> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.OilSet)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
