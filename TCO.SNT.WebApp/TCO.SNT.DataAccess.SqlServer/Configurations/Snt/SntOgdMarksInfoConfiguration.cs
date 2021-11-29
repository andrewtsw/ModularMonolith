using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntOgdMarksInfoConfiguration : IEntityTypeConfiguration<SntOgdMarksInfo>
    {
        public void Configure(EntityTypeBuilder<SntOgdMarksInfo> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.OgdMarksInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
