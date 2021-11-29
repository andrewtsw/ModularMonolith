using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class UFormSenderConfiguration : IEntityTypeConfiguration<UFormSender>
    {
        public void Configure(EntityTypeBuilder<UFormSender> builder)
        {
            builder.HasKey(x => x.UFormId);

            builder
                .HasOne(x => x.UForm)
                .WithOne(s => s.Sender)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.TaxpayerStore)
                .WithMany()
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasIndex(x => x.Tin);
        }
    }
}
