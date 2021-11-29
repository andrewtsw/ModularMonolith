using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class FavoriteProductConfiguration : IEntityTypeConfiguration<FavoriteProduct>
    {
        public void Configure(EntityTypeBuilder<FavoriteProduct> builder)
        {
            builder
                .HasKey(x => x.ProductId);

            builder.HasOne(x => x.Product)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
