using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Update_Uform_Add_Index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "UFormSenders",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "UForms",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "UFormRecipients",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "UFormInfos",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UFormSenders_Tin",
                table: "UFormSenders",
                column: "Tin");

            migrationBuilder.CreateIndex(
                name: "IX_UForms_Date",
                table: "UForms",
                column: "Date");

            migrationBuilder.CreateIndex(
                name: "IX_UForms_Number",
                table: "UForms",
                column: "Number",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_UForms_TotalSum",
                table: "UForms",
                column: "TotalSum");

            migrationBuilder.CreateIndex(
                name: "IX_UForms_Type",
                table: "UForms",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_UFormRecipients_Tin",
                table: "UFormRecipients",
                column: "Tin");

            migrationBuilder.CreateIndex(
                name: "IX_UFormInfos_RegistrationNumber",
                table: "UFormInfos",
                column: "RegistrationNumber",
                unique: true,
                filter: "[RegistrationNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UFormInfos_Status",
                table: "UFormInfos",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UFormSenders_Tin",
                table: "UFormSenders");

            migrationBuilder.DropIndex(
                name: "IX_UForms_Date",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UForms_Number",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UForms_TotalSum",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UForms_Type",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UFormRecipients_Tin",
                table: "UFormRecipients");

            migrationBuilder.DropIndex(
                name: "IX_UFormInfos_RegistrationNumber",
                table: "UFormInfos");

            migrationBuilder.DropIndex(
                name: "IX_UFormInfos_Status",
                table: "UFormInfos");

            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "UFormSenders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "UForms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Tin",
                table: "UFormRecipients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "UFormInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
