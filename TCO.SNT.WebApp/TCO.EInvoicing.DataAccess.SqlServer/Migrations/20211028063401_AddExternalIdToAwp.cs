using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class AddExternalIdToAwp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExternalId",
                schema: "ei",
                table: "Awps",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                schema: "ei",
                table: "Awps");
        }
    }
}
