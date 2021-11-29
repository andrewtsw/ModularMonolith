using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntCarCargoInfoConfiguration : IEntityTypeConfiguration<SntCarCargoInfo>
    {
        public void Configure(EntityTypeBuilder<SntCarCargoInfo> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.CarCargoInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
