using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Remove_Settings_UFormUpdatesLastUFormId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UFormUpdatesLastUFormId",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UFormUpdatesLastUFormId",
                table: "Settings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
