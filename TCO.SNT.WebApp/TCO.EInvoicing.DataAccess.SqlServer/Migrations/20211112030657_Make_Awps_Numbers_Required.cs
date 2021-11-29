using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class Make_Awps_Numbers_Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Awps_RegistrationNumber",
                schema: "ei",
                table: "Awps");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                schema: "ei",
                table: "Awps",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "ei",
                table: "Awps",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Awps_RegistrationNumber",
                schema: "ei",
                table: "Awps",
                column: "RegistrationNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Awps_RegistrationNumber",
                schema: "ei",
                table: "Awps");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                schema: "ei",
                table: "Awps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                schema: "ei",
                table: "Awps",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Awps_RegistrationNumber",
                schema: "ei",
                table: "Awps",
                column: "RegistrationNumber",
                unique: true,
                filter: "[RegistrationNumber] IS NOT NULL");
        }
    }
}
