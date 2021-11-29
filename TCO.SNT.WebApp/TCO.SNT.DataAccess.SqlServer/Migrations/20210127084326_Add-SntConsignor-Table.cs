using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntConsignorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntConsignor",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    CountryCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NonResident = table.Column<bool>(nullable: false),
                    Tin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntConsignor", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntConsignor_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntConsignor");
        }
    }
}
