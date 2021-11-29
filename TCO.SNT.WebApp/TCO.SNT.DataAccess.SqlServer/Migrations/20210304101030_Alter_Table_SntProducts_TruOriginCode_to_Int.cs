using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Alter_Table_SntProducts_TruOriginCode_to_Int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TruOriginCode",
                table: "SntProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TruOriginCode",
                table: "SntOilProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TruOriginCode",
                table: "SntProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TruOriginCode",
                table: "SntOilProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
