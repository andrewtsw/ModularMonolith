using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Remove_Balance_Unique_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("update Balances set IsActive = 1");
            migrationBuilder.Sql("update Balances set SpiritPercent = null");

            migrationBuilder.DropIndex(
                name: "IX_Balances_TaxpayerStoreId_ProductId",
                table: "Balances");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_TaxpayerStoreId",
                table: "Balances",
                column: "TaxpayerStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_TaxpayerStoreId",
                table: "Balances");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_TaxpayerStoreId_ProductId",
                table: "Balances",
                columns: new[] { "TaxpayerStoreId", "ProductId" },
                unique: true);
        }
    }
}
