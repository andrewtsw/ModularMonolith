using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCO.Finportal.Shared.Entities;

namespace TCO.Finportal.Shared.DataAccess.SqlServer.Configurations
{
    public class GroupRoleConfiguration : IEntityTypeConfiguration<GroupRole>
    {
        public void Configure(EntityTypeBuilder<GroupRole> builder)
        {
            builder.HasKey(o => new { o.GroupId, o.Role });
        }
    }
}
