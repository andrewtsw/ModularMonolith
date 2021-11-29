using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddEsfIntegrationSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BalanceIncomeUpdatesLastBalanceId",
                table: "Settings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "BalanceIncomeUpdatesLastEventDate",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "BalanceOutcomeUpdatesLastBalanceId",
                table: "Settings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "BalanceOutcomeUpdatesLastEventDate",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BalanceIncomeUpdatesLastEventDate", "BalanceOutcomeUpdatesLastEventDate" },
                values: new object[] { new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceIncomeUpdatesLastBalanceId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BalanceIncomeUpdatesLastEventDate",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BalanceOutcomeUpdatesLastBalanceId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BalanceOutcomeUpdatesLastEventDate",
                table: "Settings");
        }
    }
}
