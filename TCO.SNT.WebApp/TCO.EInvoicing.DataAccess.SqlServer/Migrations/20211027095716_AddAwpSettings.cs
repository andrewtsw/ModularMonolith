using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class AddAwpSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AwpUpdatesLastAwpId",
                schema: "ei",
                table: "Settings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "AwpUpdatesLastEventDateUtc",
                schema: "ei",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "ei",
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "AwpUpdatesLastEventDateUtc",
                value: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AwpUpdatesLastAwpId",
                schema: "ei",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "AwpUpdatesLastEventDateUtc",
                schema: "ei",
                table: "Settings");
        }
    }
}
