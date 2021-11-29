using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntProductSetConfiguration : IEntityTypeConfiguration<SntProductSet>
    {
        public void Configure(EntityTypeBuilder<SntProductSet> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.ProductSet)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
