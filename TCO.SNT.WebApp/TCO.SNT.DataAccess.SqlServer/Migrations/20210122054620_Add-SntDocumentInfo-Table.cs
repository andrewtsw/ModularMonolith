using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntDocumentInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntDocumentInfo",
                columns: table => new
                {
                    SntInfoSntId = table.Column<int>(nullable: false),
                    SntBody = table.Column<string>(nullable: false),
                    CreatorLogin = table.Column<string>(nullable: false),
                    CreatorTin = table.Column<string>(nullable: false),
                    CreatorProjectCode = table.Column<long>(nullable: true),
                    SenderSignerName = table.Column<string>(nullable: false),
                    Signature = table.Column<string>(nullable: false),
                    SignatureType = table.Column<int>(nullable: false),
                    Certificate = table.Column<string>(nullable: false),
                    SignatureValid = table.Column<bool>(nullable: false),
                    Errors = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntDocumentInfo", x => x.SntInfoSntId);
                    table.ForeignKey(
                        name: "FK_SntDocumentInfo_SntInfo_SntInfoSntId",
                        column: x => x.SntInfoSntId,
                        principalTable: "SntInfo",
                        principalColumn: "SntId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntDocumentInfo");
        }
    }
}
