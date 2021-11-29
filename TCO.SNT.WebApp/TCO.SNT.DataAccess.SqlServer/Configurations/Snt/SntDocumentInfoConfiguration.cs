using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntDocumentInfoConfiguration : IEntityTypeConfiguration<SntDocumentInfo>
    {
        public void Configure(EntityTypeBuilder<SntDocumentInfo> builder)
        {
            builder.HasKey(x => x.SntId);

            builder
                .HasOne(x => x.Snt)
                .WithOne(snt => snt.DocumentInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(x => x.Errors)
                .HasConversion(
                    v => v != null && v.Length > 0 ? JsonConvert.SerializeObject(v) : null,
                    v => !string.IsNullOrEmpty(v) ? JsonConvert.DeserializeObject<Error[]>(v) : new Error[0]);
        }
    }
}
