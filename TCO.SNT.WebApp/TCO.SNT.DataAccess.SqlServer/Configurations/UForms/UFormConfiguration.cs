using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class UFormConfiguration : IEntityTypeConfiguration<UForm>
    {
        public void Configure(EntityTypeBuilder<UForm> builder)
        {
            builder
                .HasMany(f => f.Products)
                .WithOne(p => p.ProductForm)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(f => f.SourceProducts)
                .WithOne(p => p.SourceProductForm)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .Property(x => x.Date)
                .HasColumnType("date");
                
            // Unique index for not null values
            builder
                .HasIndex(x => x.ExternalId)
                .IsUnique();

            builder
                .HasIndex(x => x.Date);

            builder
                .HasIndex(x => x.Type);

            builder
                .HasIndex(x => x.TotalSum);

            builder
                .HasIndex(x => x.Number);                
        }
    }
}
