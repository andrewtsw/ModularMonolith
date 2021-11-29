using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class ChangeSntStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Snts");

            migrationBuilder.DropForeignKey(
                name: "FK_SntAcceptanceGoodsInfo_SntInfo_SntInfoSntId",
                table: "SntAcceptanceGoodsInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SntDocumentInfo_SntInfo_SntInfoSntId",
                table: "SntDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SntOgdMarksInfo_SntInfo_SntInfoSntId",
                table: "SntOgdMarksInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntOgdMarksInfo",
                table: "SntOgdMarksInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntDocumentInfo",
                table: "SntDocumentInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntAcceptanceGoodsInfo",
                table: "SntAcceptanceGoodsInfo");

            migrationBuilder.DropColumn(
                name: "SntInfoSntId",
                table: "SntOgdMarksInfo");

            migrationBuilder.DropColumn(
                name: "SntInfoSntId",
                table: "SntDocumentInfo");

            migrationBuilder.DropColumn(
                name: "SntInfoSntId",
                table: "SntAcceptanceGoodsInfo");

            migrationBuilder.AddColumn<int>(
                name: "SntId",
                table: "SntOgdMarksInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SntId",
                table: "SntDocumentInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SntId",
                table: "SntAcceptanceGoodsInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntOgdMarksInfo",
                table: "SntOgdMarksInfo",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntDocumentInfo",
                table: "SntDocumentInfo",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntAcceptanceGoodsInfo",
                table: "SntAcceptanceGoodsInfo",
                column: "SntId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntAcceptanceGoodsInfo_Snts_SntId",
                table: "SntAcceptanceGoodsInfo",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntDocumentInfo_Snts_SntId",
                table: "SntDocumentInfo",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntOgdMarksInfo_Snts_SntId",
                table: "SntOgdMarksInfo",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntAcceptanceGoodsInfo_Snts_SntId",
                table: "SntAcceptanceGoodsInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SntDocumentInfo_Snts_SntId",
                table: "SntDocumentInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_SntOgdMarksInfo_Snts_SntId",
                table: "SntOgdMarksInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntOgdMarksInfo",
                table: "SntOgdMarksInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntDocumentInfo",
                table: "SntDocumentInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntAcceptanceGoodsInfo",
                table: "SntAcceptanceGoodsInfo");

            migrationBuilder.DropColumn(
                name: "SntId",
                table: "SntOgdMarksInfo");

            migrationBuilder.DropColumn(
                name: "SntId",
                table: "SntDocumentInfo");

            migrationBuilder.DropColumn(
                name: "SntId",
                table: "SntAcceptanceGoodsInfo");

            migrationBuilder.AddColumn<int>(
                name: "SntInfoSntId",
                table: "SntOgdMarksInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SntInfoSntId",
                table: "SntDocumentInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SntInfoSntId",
                table: "SntAcceptanceGoodsInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntOgdMarksInfo",
                table: "SntOgdMarksInfo",
                column: "SntInfoSntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntDocumentInfo",
                table: "SntDocumentInfo",
                column: "SntInfoSntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntAcceptanceGoodsInfo",
                table: "SntAcceptanceGoodsInfo",
                column: "SntInfoSntId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntAcceptanceGoodsInfo_SntInfo_SntInfoSntId",
                table: "SntAcceptanceGoodsInfo",
                column: "SntInfoSntId",
                principalTable: "SntInfo",
                principalColumn: "SntId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntDocumentInfo_SntInfo_SntInfoSntId",
                table: "SntDocumentInfo",
                column: "SntInfoSntId",
                principalTable: "SntInfo",
                principalColumn: "SntId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntOgdMarksInfo_SntInfo_SntInfoSntId",
                table: "SntOgdMarksInfo",
                column: "SntInfoSntId",
                principalTable: "SntInfo",
                principalColumn: "SntId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
