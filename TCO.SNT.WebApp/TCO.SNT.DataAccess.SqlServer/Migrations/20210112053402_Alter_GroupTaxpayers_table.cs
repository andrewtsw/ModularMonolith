using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Alter_GroupTaxpayers_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GroupTaxpayerStores_TaxpayerStoreId",
                table: "GroupTaxpayerStores",
                column: "TaxpayerStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupTaxpayerStores_TaxpayerStores_TaxpayerStoreId",
                table: "GroupTaxpayerStores",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupTaxpayerStores_TaxpayerStores_TaxpayerStoreId",
                table: "GroupTaxpayerStores");

            migrationBuilder.DropIndex(
                name: "IX_GroupTaxpayerStores_TaxpayerStoreId",
                table: "GroupTaxpayerStores");
        }
    }
}
