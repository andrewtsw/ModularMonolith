using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class UForm_Products_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Balances_ProductId1",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_UForms_UFormId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_UForms_UFormId1",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_MeasureUnitId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductId1",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_UFormId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_UFormId1",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "MeasureUnitId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "UFormId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "UFormId1",
                table: "UFormProducts");

            migrationBuilder.AlterColumn<string>(
                name: "TnvedCode",
                table: "UFormProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MeasureUnitCode",
                table: "UFormProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GsvsId",
                table: "UFormProducts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarkingCode",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductFormId",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceProductFormId",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_MeasureUnits_Code",
                table: "MeasureUnits",
                column: "Code");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Balances_ProductId",
                table: "Balances",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_MeasureUnitCode",
                table: "UFormProducts",
                column: "MeasureUnitCode");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductFormId",
                table: "UFormProducts",
                column: "ProductFormId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_SourceProductFormId",
                table: "UFormProducts",
                column: "SourceProductFormId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_UForms_ProductFormId",
                table: "UFormProducts",
                column: "ProductFormId",
                principalTable: "UForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Balances_ProductId",
                table: "UFormProducts",
                column: "ProductId",
                principalTable: "Balances",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_UForms_SourceProductFormId",
                table: "UFormProducts",
                column: "SourceProductFormId",
                principalTable: "UForms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_UForms_ProductFormId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Balances_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_UForms_SourceProductFormId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_MeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductFormId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_SourceProductFormId",
                table: "UFormProducts");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_MeasureUnits_Code",
                table: "MeasureUnits");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Balances_ProductId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "MarkingCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ProductFormId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "SourceProductFormId",
                table: "UFormProducts");

            migrationBuilder.AlterColumn<string>(
                name: "TnvedCode",
                table: "UFormProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MeasureUnitCode",
                table: "UFormProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "GsvsId",
                table: "UFormProducts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MeasureUnitId",
                table: "UFormProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "UFormProducts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UFormId",
                table: "UFormProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UFormId1",
                table: "UFormProducts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_MeasureUnitId",
                table: "UFormProducts",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId1",
                table: "UFormProducts",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_UFormId",
                table: "UFormProducts",
                column: "UFormId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_UFormId1",
                table: "UFormProducts",
                column: "UFormId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts",
                column: "GsvsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_MeasureUnits_MeasureUnitId",
                table: "UFormProducts",
                column: "MeasureUnitId",
                principalTable: "MeasureUnits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Balances_ProductId1",
                table: "UFormProducts",
                column: "ProductId1",
                principalTable: "Balances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_UForms_UFormId",
                table: "UFormProducts",
                column: "UFormId",
                principalTable: "UForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_UForms_UFormId1",
                table: "UFormProducts",
                column: "UFormId1",
                principalTable: "UForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
