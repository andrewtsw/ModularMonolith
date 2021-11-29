using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class ErrorCodeConfiguration : IEntityTypeConfiguration<ErrorCode>
    {
        public void Configure(EntityTypeBuilder<ErrorCode> builder)
        {
            builder
                .HasKey(x => x.Code);
        }
    }
}
