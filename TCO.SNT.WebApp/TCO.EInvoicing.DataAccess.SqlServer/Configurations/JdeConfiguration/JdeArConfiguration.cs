using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.EInvoicing.Entities.Jde;

namespace TCO.EInvoicing.DataAccess.SqlServer.Configurations.Jde
{
    public class JdeArConfiguration : IEntityTypeConfiguration<JdeArInvoice>
    {
        public void Configure(EntityTypeBuilder<JdeArInvoice> builder)
        {
            builder
                .HasKey(x => new { x.JdeArF03B11DocumentNumber, x.JdeArF03B11DocumentType, x.JdeArF03B11DocumentPayItem });

            builder
                .Property(x => x.Id)
                .UseIdentityColumn();

            builder
                .HasAlternateKey(x => x.Id);
        }
    }
}
