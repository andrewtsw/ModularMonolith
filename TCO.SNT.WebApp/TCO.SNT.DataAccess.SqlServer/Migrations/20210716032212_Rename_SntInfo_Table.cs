using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Rename_SntInfo_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntInfo_Snts_SntId",
                table: "SntInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntInfo",
                table: "SntInfo");

            migrationBuilder.RenameTable(
                name: "SntInfo",
                newName: "SntInfos");

            migrationBuilder.RenameIndex(
                name: "IX_SntInfo_Status",
                table: "SntInfos",
                newName: "IX_SntInfos_Status");

            migrationBuilder.RenameIndex(
                name: "IX_SntInfo_RegistrationNumber",
                table: "SntInfos",
                newName: "IX_SntInfos_RegistrationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_SntInfo_LastUpdateDateUtc",
                table: "SntInfos",
                newName: "IX_SntInfos_LastUpdateDateUtc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntInfos",
                table: "SntInfos",
                column: "SntId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntInfos_Snts_SntId",
                table: "SntInfos",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntInfos_Snts_SntId",
                table: "SntInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntInfos",
                table: "SntInfos");

            migrationBuilder.RenameTable(
                name: "SntInfos",
                newName: "SntInfo");

            migrationBuilder.RenameIndex(
                name: "IX_SntInfos_Status",
                table: "SntInfo",
                newName: "IX_SntInfo_Status");

            migrationBuilder.RenameIndex(
                name: "IX_SntInfos_RegistrationNumber",
                table: "SntInfo",
                newName: "IX_SntInfo_RegistrationNumber");

            migrationBuilder.RenameIndex(
                name: "IX_SntInfos_LastUpdateDateUtc",
                table: "SntInfo",
                newName: "IX_SntInfo_LastUpdateDateUtc");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntInfo",
                table: "SntInfo",
                column: "SntId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntInfo_Snts_SntId",
                table: "SntInfo",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
