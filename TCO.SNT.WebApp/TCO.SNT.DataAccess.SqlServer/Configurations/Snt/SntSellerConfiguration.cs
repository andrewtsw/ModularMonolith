using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntSellerConfiguration : IEntityTypeConfiguration<SntSeller>
    {
        public void Configure(EntityTypeBuilder<SntSeller> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.Seller)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Statuses)
                .HasConversion(
                    v => v != null && v.Length > 0 ? JsonConvert.SerializeObject(v) : null,
                    v => !string.IsNullOrEmpty(v) ? JsonConvert.DeserializeObject<SntParticipantType[]>(v) : new SntParticipantType[0]);

            builder.HasIndex(x => x.Tin);
        }
    }
}
