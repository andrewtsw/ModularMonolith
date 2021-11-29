using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_MeasureUnit_To_Balances : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasureUnitCode",
                table: "Balances");

            migrationBuilder.AddColumn<string>(
                name: "ExternalMeasureUnitCode",
                table: "Balances",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitId",
                table: "Balances",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_MeasureUnitId",
                table: "Balances",
                column: "MeasureUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_MeasureUnits_MeasureUnitId",
                table: "Balances",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_MeasureUnits_MeasureUnitId",
                table: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_Balances_MeasureUnitId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "ExternalMeasureUnitCode",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "MeasureUnitId",
                table: "Balances");

            migrationBuilder.AddColumn<string>(
                name: "MeasureUnitCode",
                table: "Balances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
