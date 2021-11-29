using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasIndex(x => x.FixedId)
                .IsUnique();

            // This index should be unique. 
            // But there are duplicated codes where endDate is in the past
            builder
                .HasIndex(x => x.Code);
        }
    }
}
