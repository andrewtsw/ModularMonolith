using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Remove_Unused_Store_Columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxpayerStores_TaxpayerStores_ParentId",
                table: "TaxpayerStores");

            migrationBuilder.DropIndex(
                name: "IX_TaxpayerStores_ParentId",
                table: "TaxpayerStores");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "TaxpayerStores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "TaxpayerStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxpayerStores_ParentId",
                table: "TaxpayerStores",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxpayerStores_TaxpayerStores_ParentId",
                table: "TaxpayerStores",
                column: "ParentId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id");
        }
    }
}
