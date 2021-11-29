using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Remove_CancelReason_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UFormInfos_CancelReason",
                table: "UFormInfos");

            migrationBuilder.AlterColumn<string>(
                name: "CancelReason",
                table: "UFormInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CancelReason",
                table: "UFormInfos",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UFormInfos_CancelReason",
                table: "UFormInfos",
                column: "CancelReason");
        }
    }
}
