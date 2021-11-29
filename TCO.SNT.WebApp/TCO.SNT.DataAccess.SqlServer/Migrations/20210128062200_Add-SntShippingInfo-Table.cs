using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntShippingInfoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntShippingInfo",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    BoardNumber = table.Column<string>(nullable: true),
                    CarStateNumber = table.Column<string>(nullable: true),
                    CarriageNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NonResident = table.Column<bool>(nullable: true),
                    ShipNumber = table.Column<string>(nullable: true),
                    Tin = table.Column<string>(nullable: true),
                    TrailerStateNumber = table.Column<string>(nullable: true),
                    TransportTypes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntShippingInfo", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntShippingInfo_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntShippingInfo");
        }
    }
}
