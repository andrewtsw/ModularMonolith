using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_UForm_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CancelReason",
                table: "UFormInfos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UForms_Number",
                table: "UForms",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_UFormInfos_CancelReason",
                table: "UFormInfos",
                column: "CancelReason");

            migrationBuilder.CreateIndex(
                name: "IX_UFormInfos_LastUpdateDateUtc",
                table: "UFormInfos",
                column: "LastUpdateDateUtc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UForms_Number",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UFormInfos_CancelReason",
                table: "UFormInfos");

            migrationBuilder.DropIndex(
                name: "IX_UFormInfos_LastUpdateDateUtc",
                table: "UFormInfos");

            migrationBuilder.AlterColumn<string>(
                name: "CancelReason",
                table: "UFormInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
