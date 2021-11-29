using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class ChangeUFornColumnsDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputDate",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "UForms");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "InputDateUtc",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastUpdateDateUtc",
                table: "UForms",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UFormUpdatesLastEventDateUtc",
                table: "Settings",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UFormUpdatesLastEventDateUtc",
                value: new DateTimeOffset(new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InputDateUtc",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateUtc",
                table: "UForms");

            migrationBuilder.AddColumn<DateTime>(
                name: "InputDate",
                table: "UForms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "UForms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UFormUpdatesLastEventDateUtc",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.UpdateData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UFormUpdatesLastEventDateUtc",
                value: new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
