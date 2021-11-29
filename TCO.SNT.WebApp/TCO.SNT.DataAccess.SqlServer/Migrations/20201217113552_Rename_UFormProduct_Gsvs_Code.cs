using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Rename_UFormProduct_Gsvs_Code : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GsvsCode",
                table: "UFormProducts");

            migrationBuilder.AddColumn<string>(
                name: "ExternalGsvsCode",
                table: "UFormProducts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalGsvsCode",
                table: "UFormProducts");

            migrationBuilder.AddColumn<string>(
                name: "GsvsCode",
                table: "UFormProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
