using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class UFormRecipientConfiguration : IEntityTypeConfiguration<UFormRecipient>
    {
        public void Configure(EntityTypeBuilder<UFormRecipient> builder)
        {
            builder.HasKey(x => x.UFormId);

            builder
                .HasOne(x => x.UForm)
                .WithOne(r => r.Recipient)
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
