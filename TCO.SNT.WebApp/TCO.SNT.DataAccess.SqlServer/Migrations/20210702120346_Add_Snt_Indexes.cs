using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_Snt_Indexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "SntSellers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Snts",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "SntInfo",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "SntCustomers",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SntSellers_Tin",
                table: "SntSellers",
                column: "Tin");

            migrationBuilder.CreateIndex(
                name: "IX_Snts_Date",
                table: "Snts",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_Snts_Number",
                table: "Snts",
                column: "Number");

            migrationBuilder.CreateIndex(
                name: "IX_Snts_SntType",
                table: "Snts",
                column: "SntType");

            migrationBuilder.CreateIndex(
                name: "IX_SntInfo_LastUpdateDateUtc",
                table: "SntInfo",
                column: "LastUpdateDateUtc");

            migrationBuilder.CreateIndex(
                name: "IX_SntInfo_RegistrationNumber",
                table: "SntInfo",
                column: "RegistrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_SntInfo_Status",
                table: "SntInfo",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_SntCustomers_Tin",
                table: "SntCustomers",
                column: "Tin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SntSellers_Tin",
                table: "SntSellers");

            migrationBuilder.DropIndex(
                name: "IX_Snts_Date",
                table: "Snts");

            migrationBuilder.DropIndex(
                name: "IX_Snts_Number",
                table: "Snts");

            migrationBuilder.DropIndex(
                name: "IX_Snts_SntType",
                table: "Snts");

            migrationBuilder.DropIndex(
                name: "IX_SntInfo_LastUpdateDateUtc",
                table: "SntInfo");

            migrationBuilder.DropIndex(
                name: "IX_SntInfo_RegistrationNumber",
                table: "SntInfo");

            migrationBuilder.DropIndex(
                name: "IX_SntInfo_Status",
                table: "SntInfo");

            migrationBuilder.DropIndex(
                name: "IX_SntCustomers_Tin",
                table: "SntCustomers");

            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "SntSellers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Snts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "SntInfo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "SntCustomers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
