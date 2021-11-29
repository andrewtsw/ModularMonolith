using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntExportAndSntImportTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntExport",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    ExportType = table.Column<int>(nullable: false),
                    ExternalSezCode = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntExport", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntExport_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SntImport",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    ImportType = table.Column<int>(nullable: false),
                    ExternalSezCode = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntImport", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntImport_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntExport");

            migrationBuilder.DropTable(
                name: "SntImport");
        }
    }
}
