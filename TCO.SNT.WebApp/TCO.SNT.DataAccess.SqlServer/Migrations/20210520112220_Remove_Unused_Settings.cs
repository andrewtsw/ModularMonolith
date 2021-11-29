using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Remove_Unused_Settings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceIncomeUpdatesLastBalanceId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BalanceIncomeUpdatesLastEventDateUtc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BalanceOutcomeUpdatesLastBalanceId",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "BalanceOutcomeUpdatesLastEventDateUtc",
                table: "Settings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BalanceIncomeUpdatesLastBalanceId",
                table: "Settings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "BalanceIncomeUpdatesLastEventDateUtc",
                table: "Settings",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<long>(
                name: "BalanceOutcomeUpdatesLastBalanceId",
                table: "Settings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "BalanceOutcomeUpdatesLastEventDateUtc",
                table: "Settings",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BalanceIncomeUpdatesLastEventDateUtc", "BalanceOutcomeUpdatesLastEventDateUtc" },
                values: new object[] { new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
