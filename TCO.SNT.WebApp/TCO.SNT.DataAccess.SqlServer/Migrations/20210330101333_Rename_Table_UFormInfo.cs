using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Rename_Table_UFormInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormInfo_UForms_UFormId",
                table: "UFormInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFormInfo",
                table: "UFormInfo");

            migrationBuilder.RenameTable(
                name: "UFormInfo",
                newName: "UFormInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFormInfos",
                table: "UFormInfos",
                column: "UFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormInfos_UForms_UFormId",
                table: "UFormInfos",
                column: "UFormId",
                principalTable: "UForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormInfos_UForms_UFormId",
                table: "UFormInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFormInfos",
                table: "UFormInfos");

            migrationBuilder.RenameTable(
                name: "UFormInfos",
                newName: "UFormInfo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFormInfo",
                table: "UFormInfo",
                column: "UFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormInfo_UForms_UFormId",
                table: "UFormInfo",
                column: "UFormId",
                principalTable: "UForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
