using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.Finportal.Shared.DataAccess.SqlServer.Migrations
{
    public partial class Shared_Module_Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.Sql("ALTER SCHEMA shared TRANSFER [dbo].[EsfUserProfiles]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER SCHEMA dbo TRANSFER [shared].[EsfUserProfiles]");
        }
    }
}
