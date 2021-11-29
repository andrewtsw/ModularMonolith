using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Alter_GroupTaxpayerStores_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTaxpayers");

            migrationBuilder.CreateTable(
                name: "GroupTaxpayerStores",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(nullable: false),
                    TaxpayerStoreId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<Guid>(maxLength: 36, nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTaxpayerStores", x => new { x.GroupId, x.TaxpayerStoreId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupTaxpayerStores");

            migrationBuilder.CreateTable(
                name: "GroupTaxpayers",
                columns: table => new
                {
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxpayerId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTaxpayers", x => new { x.GroupId, x.TaxpayerId });
                });
        }
    }
}
