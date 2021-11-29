using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.Finportal.Shared.Entities;

namespace TCO.Finportal.Shared.DataAccess.SqlServer.Configurations
{
    public class EsfUserProfileConfiguration : IEntityTypeConfiguration<EsfUserProfile>
    {
        public void Configure(EntityTypeBuilder<EsfUserProfile> builder)
        {
            builder.HasKey(x => x.UserId);
            builder.Property(x => x.UserId)
                    .ValueGeneratedNever();
        }
    }
}
