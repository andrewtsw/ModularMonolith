using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntAcceptanceGoodsInfoConfiguration : IEntityTypeConfiguration<SntAcceptanceGoodsInfo>
    {
        public void Configure(EntityTypeBuilder<SntAcceptanceGoodsInfo> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.AcceptanceGoodsInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.AcceptanceOrRejectionDate)
                .HasColumnType("date");
        }
    }
}
