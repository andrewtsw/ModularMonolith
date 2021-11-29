using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class ChangeTaxpayerStoreLesseeContractDateColumnDataType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LesseeContractDate",
                table: "TaxpayerStores");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LesseeContractDateUtc",
                table: "TaxpayerStores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LesseeContractDateUtc",
                table: "TaxpayerStores");

            migrationBuilder.AddColumn<DateTime>(
                name: "LesseeContractDate",
                table: "TaxpayerStores",
                type: "datetime2",
                nullable: true);
        }
    }
}
