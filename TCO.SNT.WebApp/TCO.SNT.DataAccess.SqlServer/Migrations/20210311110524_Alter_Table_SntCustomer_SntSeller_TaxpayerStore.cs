using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Alter_Table_SntCustomer_SntSeller_TaxpayerStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SntSellers_TaxpayerStoreId",
                table: "SntSellers",
                column: "TaxpayerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SntCustomers_TaxpayerStoreId",
                table: "SntCustomers",
                column: "TaxpayerStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntCustomers_TaxpayerStores_TaxpayerStoreId",
                table: "SntCustomers",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SntSellers_TaxpayerStores_TaxpayerStoreId",
                table: "SntSellers",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntCustomers_TaxpayerStores_TaxpayerStoreId",
                table: "SntCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_SntSellers_TaxpayerStores_TaxpayerStoreId",
                table: "SntSellers");

            migrationBuilder.DropIndex(
                name: "IX_SntSellers_TaxpayerStoreId",
                table: "SntSellers");

            migrationBuilder.DropIndex(
                name: "IX_SntCustomers_TaxpayerStoreId",
                table: "SntCustomers");
        }
    }
}
