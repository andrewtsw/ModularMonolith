using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class ImproveSntdbstructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntExports");

            migrationBuilder.DropTable(
                name: "SntImports");

            migrationBuilder.DropIndex(
                name: "IX_Snts_ExternalId",
                table: "Snts");

            migrationBuilder.AlterColumn<long>(
                name: "ExternalId",
                table: "Snts",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DigitalMarkingNotificationDate",
                table: "Snts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DatePaper",
                table: "Snts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExportType",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExternalExportSezCode",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExternalImportSezCode",
                table: "Snts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImportType",
                table: "Snts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Snts_ExternalId",
                table: "Snts",
                column: "ExternalId",
                unique: true,
                filter: "[ExternalId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Snts_ExternalId",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "ExportType",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "ExternalExportSezCode",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "ExternalImportSezCode",
                table: "Snts");

            migrationBuilder.DropColumn(
                name: "ImportType",
                table: "Snts");

            migrationBuilder.AlterColumn<long>(
                name: "ExternalId",
                table: "Snts",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DigitalMarkingNotificationDate",
                table: "Snts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DatePaper",
                table: "Snts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SntExports",
                columns: table => new
                {
                    SntId = table.Column<int>(type: "int", nullable: false),
                    ExportType = table.Column<int>(type: "int", nullable: false),
                    ExternalSezCode = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntExports", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntExports_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SntImports",
                columns: table => new
                {
                    SntId = table.Column<int>(type: "int", nullable: false),
                    ExternalSezCode = table.Column<long>(type: "bigint", nullable: true),
                    ImportType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntImports", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntImports_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Snts_ExternalId",
                table: "Snts",
                column: "ExternalId",
                unique: true);
        }
    }
}
