using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntShippingInfoConfiguration : IEntityTypeConfiguration<SntShippingInfo>
    {
        public void Configure(EntityTypeBuilder<SntShippingInfo> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.ShippingInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.TransportTypes)
                .HasConversion(
                    v => v != null && v.Length > 0 ? JsonConvert.SerializeObject(v) : null,
                    v => !string.IsNullOrEmpty(v) ? JsonConvert.DeserializeObject<SntTransporterTransportType[]>(v) : new SntTransporterTransportType[0]);

        }
    }
}
