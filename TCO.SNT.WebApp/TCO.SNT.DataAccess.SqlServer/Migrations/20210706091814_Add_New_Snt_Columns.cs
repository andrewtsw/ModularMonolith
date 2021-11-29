using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_New_Snt_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MptId",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "SntConsignors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalInfo",
                table: "SntConsignees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MptId",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "SntConsignors");

            migrationBuilder.DropColumn(
                name: "AdditionalInfo",
                table: "SntConsignees");
        }
    }
}
