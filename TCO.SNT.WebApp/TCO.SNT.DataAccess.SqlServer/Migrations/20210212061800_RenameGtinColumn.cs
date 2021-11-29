using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class RenameGtinColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalGtinCode",
                table: "SntProducts");

            migrationBuilder.AddColumn<int>(
                name: "BalanceId",
                table: "SntProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GtinCode",
                table: "SntProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitId",
                table: "SntProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SntProducts_BalanceId",
                table: "SntProducts",
                column: "BalanceId");

            migrationBuilder.CreateIndex(
                name: "IX_SntProducts_MeasureUnitId",
                table: "SntProducts",
                column: "MeasureUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntProducts_Balances_BalanceId",
                table: "SntProducts",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SntProducts_MeasureUnits_MeasureUnitId",
                table: "SntProducts",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntProducts_Balances_BalanceId",
                table: "SntProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SntProducts_MeasureUnits_MeasureUnitId",
                table: "SntProducts");

            migrationBuilder.DropIndex(
                name: "IX_SntProducts_BalanceId",
                table: "SntProducts");

            migrationBuilder.DropIndex(
                name: "IX_SntProducts_MeasureUnitId",
                table: "SntProducts");

            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "SntProducts");

            migrationBuilder.DropColumn(
                name: "GtinCode",
                table: "SntProducts");

            migrationBuilder.DropColumn(
                name: "MeasureUnitId",
                table: "SntProducts");

            migrationBuilder.AddColumn<string>(
                name: "ExternalGtinCode",
                table: "SntProducts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
