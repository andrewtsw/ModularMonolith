using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations
{
    internal class AwpConfiguration : IEntityTypeConfiguration<Awp>
    {
        public void Configure(EntityTypeBuilder<Awp> builder)
        {
            builder
                .Property(x => x.AwpDate)
                .HasColumnType("date");

            builder
                .Property(x => x.AwpSignDate)
                .HasColumnType("date");

            builder
                .HasIndex(x => x.ExternalId)
                .IsUnique();

            builder
                .HasIndex(x => x.RegistrationNumber)
                .IsUnique();
        }
    }
}
