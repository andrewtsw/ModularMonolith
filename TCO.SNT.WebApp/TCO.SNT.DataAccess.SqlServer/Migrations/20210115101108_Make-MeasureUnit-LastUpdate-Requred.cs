using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class MakeMeasureUnitLastUpdateRequred : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Balances");
            migrationBuilder.Sql("delete from MeasureUnits");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdateDateUtc",
                table: "MeasureUnits",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdateDateUtc",
                table: "MeasureUnits",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
