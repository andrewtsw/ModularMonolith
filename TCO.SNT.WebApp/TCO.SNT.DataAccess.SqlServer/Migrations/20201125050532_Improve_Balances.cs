using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Improve_Balances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_ExternalBalanceId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "ExternalBalanceId",
                table: "Balances");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Balances",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ProductId",
                table: "Balances",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_ProductId",
                table: "Balances");

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "Balances",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ExternalBalanceId",
                table: "Balances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ExternalBalanceId",
                table: "Balances",
                column: "ExternalBalanceId",
                unique: true);
        }
    }
}
