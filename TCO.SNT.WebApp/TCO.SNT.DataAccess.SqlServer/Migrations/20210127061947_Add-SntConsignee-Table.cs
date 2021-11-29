using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntConsigneeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntConsignee",
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
                    table.PrimaryKey("PK_SntConsignee", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntConsignee_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntConsignee");
        }
    }
}
