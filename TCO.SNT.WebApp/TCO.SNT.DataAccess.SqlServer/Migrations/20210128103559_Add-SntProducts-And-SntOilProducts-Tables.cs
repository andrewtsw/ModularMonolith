using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class AddSntProductsAndSntOilProductsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SntOilProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SntId = table.Column<int>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    DeclarationNumberForSnt = table.Column<string>(nullable: true),
                    ExciseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExciseRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NdsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NdsRate = table.Column<int>(nullable: true),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceWithoutTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    ProductNumber = table.Column<string>(nullable: false),
                    ProductNumberInDeclaration = table.Column<string>(nullable: true),
                    TnvedCode = table.Column<string>(nullable: false),
                    TruOriginCode = table.Column<string>(nullable: false),
                    ExternalMeasureUnitCode = table.Column<string>(nullable: false),
                    PinCode = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntOilProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SntOilProducts_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SntProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SntId = table.Column<int>(nullable: false),
                    AdditionalInfo = table.Column<string>(nullable: true),
                    DeclarationNumberForSnt = table.Column<string>(nullable: true),
                    ExciseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ExciseRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NdsAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NdsRate = table.Column<int>(nullable: true),
                    PriceWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceWithoutTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<string>(nullable: true),
                    ProductNumber = table.Column<string>(nullable: false),
                    ProductNumberInDeclaration = table.Column<string>(nullable: true),
                    TnvedCode = table.Column<string>(nullable: false),
                    TruOriginCode = table.Column<string>(nullable: false),
                    ExternalGtinCode = table.Column<string>(nullable: true),
                    ExternalMeasureUnitCode = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductName = table.Column<string>(nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SntProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SntProducts_Snts_SntId",
                        column: x => x.SntId,
                        principalTable: "Snts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SntOilProducts_SntId",
                table: "SntOilProducts",
                column: "SntId");

            migrationBuilder.CreateIndex(
                name: "IX_SntProducts_SntId",
                table: "SntProducts",
                column: "SntId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SntOilProducts");

            migrationBuilder.DropTable(
                name: "SntProducts");
        }
    }
}
