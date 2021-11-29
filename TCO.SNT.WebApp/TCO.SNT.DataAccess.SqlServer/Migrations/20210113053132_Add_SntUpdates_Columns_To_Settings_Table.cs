using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_SntUpdates_Columns_To_Settings_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SntUpdatesLastEventDateUtc",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "SntUpdatesLastSntId",
                table: "Settings",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "SntUpdatesLastEventDateUtc",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SntUpdatesLastEventDateUtc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SntUpdatesLastSntId",
                table: "Settings");
        }
    }
}
