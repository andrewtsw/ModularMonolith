using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntInfoConfiguration : IEntityTypeConfiguration<SntInfo>
    {
        public void Configure(EntityTypeBuilder<SntInfo> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.SntInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.RegistrationNumber);

            builder.HasIndex(x => x.Status);

            builder.HasIndex(x => x.LastUpdateDateUtc);
        }
    }
}
