using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations.UForms
{
    internal class UFormInfoConfiguration : IEntityTypeConfiguration<UFormInfo>
    {
        public void Configure(EntityTypeBuilder<UFormInfo> builder)
        {
            builder.HasKey(x => x.UFormId);

            builder
                .HasOne(x => x.UForm)
                .WithOne(inf => inf.UFormInfo)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasIndex(x => x.Status);

            builder
               .HasIndex(x => x.RegistrationNumber)
               .IsUnique();

            builder
                .HasIndex(x => x.LastUpdateDateUtc);
        }
    }
}
