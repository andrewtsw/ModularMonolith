using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Change_Balances_Unique_Key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Balances_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Balances_ProductId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_ProductId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_TaxpayerStoreId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UFormProducts");

            migrationBuilder.AddColumn<int>(
                name: "BalanceId",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExternalProductId",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_BalanceId",
                table: "UFormProducts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_TaxpayerStoreId_ProductId",
                table: "Balances",
                columns: new[] { "TaxpayerStoreId", "ProductId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Balances_BalanceId",
                table: "UFormProducts",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Balances_BalanceId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_BalanceId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_Balances_TaxpayerStoreId_ProductId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ExternalProductId",
                table: "UFormProducts");

            migrationBuilder.AddColumn<long>(
                name: "ProductId",
                table: "UFormProducts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Balances_ProductId",
                table: "Balances",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ProductId",
                table: "Balances",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_TaxpayerStoreId",
                table: "Balances",
                column: "TaxpayerStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Balances_ProductId",
                table: "UFormProducts",
                column: "ProductId",
                principalTable: "Balances",
                principalColumn: "ProductId");
        }
    }
}
