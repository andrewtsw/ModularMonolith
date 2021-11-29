using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntConsignorConfiguration : IEntityTypeConfiguration<SntConsignor>
    {
        public void Configure(EntityTypeBuilder<SntConsignor> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.Consignor)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
