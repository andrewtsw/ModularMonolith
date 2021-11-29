using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntConsigneeConfiguration : IEntityTypeConfiguration<SntConsignee>
    {
        public void Configure(EntityTypeBuilder<SntConsignee> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.Consignee)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
