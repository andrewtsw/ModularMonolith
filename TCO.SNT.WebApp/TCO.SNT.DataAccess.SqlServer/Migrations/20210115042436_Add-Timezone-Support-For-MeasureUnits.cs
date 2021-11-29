using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddTimezoneSupportForMeasureUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "MeasureUnits");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "MeasureUnitsLastEventDateUtc",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdateDateUtc",
                table: "MeasureUnits",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeasureUnitsLastEventDateUtc",
                value: new DateTimeOffset(new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnitsLastEventDateUtc",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateUtc",
                table: "MeasureUnits");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "MeasureUnits",
                type: "datetime2",
                nullable: true);
        }
    }
}
