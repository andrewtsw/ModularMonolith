using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class GroupTaxpayerStoreConfiguration : IEntityTypeConfiguration<GroupTaxpayerStore>
    {
        public void Configure(EntityTypeBuilder<GroupTaxpayerStore> builder)
        {
            builder.HasKey(o => new { o.GroupId, o.TaxpayerStoreId });
            builder.HasOne(x => x.TaxpayerStore)
               .WithMany()
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
