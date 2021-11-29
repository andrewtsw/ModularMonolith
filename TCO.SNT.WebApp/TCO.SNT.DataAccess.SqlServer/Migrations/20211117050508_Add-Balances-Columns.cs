using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddBalancesColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "Balances",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DutyType",
                table: "Balances",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "DutyType",
                table: "Balances");
        }
    }
}
