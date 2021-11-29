using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddProductSetAndOilSetTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntOilSet",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    TotalExciseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNdsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPriceWithoutTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KogdOfRecipient = table.Column<string>(nullable: true),
                    KogdOfSender = table.Column<string>(nullable: true),
                    OperationCode = table.Column<string>(nullable: true),
                    ProductSellerType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntOilSet", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntOilSet_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SntProductSet",
                columns: table => new
                {
                    SntId = table.Column<int>(nullable: false),
                    TotalExciseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalNdsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalPriceWithoutTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntProductSet", x => x.SntId);
                    table.ForeignKey(
                        name: "FK_SntProductSet_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntOilSet");

            migrationBuilder.DropTable(
                name: "SntProductSet");
        }
    }
}
