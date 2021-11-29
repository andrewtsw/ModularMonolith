using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntV1columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Snts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CurrencyRate",
                table: "Snts",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DatePaper",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DigitalMarkingNotificationDate",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DigitalMarkingNotificationNumber",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReasonPaper",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransferType",
                table: "Snts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "CurrencyRate",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "DatePaper",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "DigitalMarkingNotificationDate",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "DigitalMarkingNotificationNumber",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "ReasonPaper",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "Snts");
        }
    }
}
