using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddNavigationColumnsToOilProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BalanceId",
                table: "SntOilProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitId",
                table: "SntOilProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SntOilProducts_BalanceId",
                table: "SntOilProducts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SntOilProducts_MeasureUnitId",
                table: "SntOilProducts",
                column: "MeasureUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntOilProducts_Balances_BalanceId",
                table: "SntOilProducts",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SntOilProducts_MeasureUnits_MeasureUnitId",
                table: "SntOilProducts",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntOilProducts_Balances_BalanceId",
                table: "SntOilProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SntOilProducts_MeasureUnits_MeasureUnitId",
                table: "SntOilProducts");

            migrationBuilder.DropIndex(
                name: "IX_SntOilProducts_BalanceId",
                table: "SntOilProducts");

            migrationBuilder.DropIndex(
                name: "IX_SntOilProducts_MeasureUnitId",
                table: "SntOilProducts");

            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "SntOilProducts");

            migrationBuilder.DropColumn(
                name: "MeasureUnitId",
                table: "SntOilProducts");
        }
    }
}
