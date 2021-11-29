using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddedGsvsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GsvsId",
                table: "SntProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GsvsId",
                table: "SntOilProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SntProducts_GsvsId",
                table: "SntProducts",
                column: "GsvsId");

            migrationBuilder.CreateIndex(
                name: "IX_SntOilProducts_GsvsId",
                table: "SntOilProducts",
                column: "GsvsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntOilProducts_Products_GsvsId",
                table: "SntOilProducts",
                column: "GsvsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SntProducts_Products_GsvsId",
                table: "SntProducts",
                column: "GsvsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntOilProducts_Products_GsvsId",
                table: "SntOilProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_SntProducts_Products_GsvsId",
                table: "SntProducts");

            migrationBuilder.DropIndex(
                name: "IX_SntProducts_GsvsId",
                table: "SntProducts");

            migrationBuilder.DropIndex(
                name: "IX_SntOilProducts_GsvsId",
                table: "SntOilProducts");

            migrationBuilder.DropColumn(
                name: "GsvsId",
                table: "SntProducts");

            migrationBuilder.DropColumn(
                name: "GsvsId",
                table: "SntOilProducts");
        }
    }
}
