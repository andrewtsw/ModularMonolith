using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Change_UFormProducts_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_MeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MeasureUnits_Code",
                table: "MeasureUnits");

            migrationBuilder.DropColumn(
                name: "GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "MeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.AddColumn<string>(
                name: "ExternalMeasureUnitCode",
                table: "UFormProducts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitId",
                table: "UFormProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "UFormProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_MeasureUnitId",
                table: "UFormProducts",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitId",
                table: "UFormProducts",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Products_ProductId",
                table: "UFormProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Products_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_MeasureUnitId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ExternalMeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "MeasureUnitId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "UFormProducts");

            migrationBuilder.AddColumn<int>(
                name: "GsvsId",
                table: "UFormProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MeasureUnitCode",
                table: "UFormProducts",
                type: "nvarchar(16)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MeasureUnits_Code",
                table: "MeasureUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_GsvsId",
                table: "UFormProducts",
                column: "GsvsId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_MeasureUnitCode",
                table: "UFormProducts",
                column: "MeasureUnitCode");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts",
                column: "GsvsId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitCode",
                table: "UFormProducts",
                column: "MeasureUnitCode",
                principalTable: "MeasureUnits",
                principalColumn: "Code");
        }
    }
}
