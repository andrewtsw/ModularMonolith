using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntCarCargoModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntCarCargoInfo",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    DriverFio = table.Column<string>(nullable: true),
                    DriverTin = table.Column<string>(nullable: true),
                    StampPrintNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntCarCargoInfo", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntCarCargoInfo_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntCarCargoInfo");
        }
    }
}
