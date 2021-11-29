using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class SntConfiguration : IEntityTypeConfiguration<Snt>
    {
        public void Configure(EntityTypeBuilder<Snt> builder)
        {
            builder
                .HasIndex(x => x.ExternalId)
                .IsUnique();

            builder
                .Property(x => x.Date)
                .HasColumnType("date");

            builder
                .Property(x => x.ShippingDate)
                .HasColumnType("date");

            builder
                .Property(x => x.DatePaper)
                .HasColumnType("date");

            builder
                .Property(x => x.DigitalMarkingNotificationDate)
                .HasColumnType("date");

            builder.HasIndex(x => x.Number);

            builder.HasIndex(x => x.Date);

            builder.HasIndex(x => x.SntType);
        }
    }
}
