using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class RenameSettingDatesColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BalanceIncomeUpdatesLastEventDate",
                table: "Settings",
                newName: "BalanceIncomeUpdatesLastEventDateUtc");

            migrationBuilder.RenameColumn(
                name: "BalanceOutcomeUpdatesLastEventDate",
                table: "Settings",
                newName: "BalanceOutcomeUpdatesLastEventDateUtc");

            migrationBuilder.RenameColumn(
                name: "UFormUpdatesLastEventDate",
                table: "Settings",
                newName: "UFormUpdatesLastEventDateUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BalanceIncomeUpdatesLastEventDateUtc",
                table: "Settings",
                newName: "BalanceIncomeUpdatesLastEventDate");

            migrationBuilder.RenameColumn(
                name: "BalanceOutcomeUpdatesLastEventDateUtc",
                table: "Settings",
                newName: "BalanceOutcomeUpdatesLastEventDate");

            migrationBuilder.RenameColumn(
                name: "UFormUpdatesLastEventDateUtc",
                table: "Settings",
                newName: "UFormUpdatesLastEventDate");
        }
    }
}
