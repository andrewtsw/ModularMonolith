using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Add_UForms_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    TotalSum = table.Column<decimal>(nullable: false),
                    TaxpayerStoreId = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ExternalId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UForms_TaxpayerStores_TaxpayerStoreId",
                        column: x => x.TaxpayerStoreId,
                        principalTable: "TaxpayerStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UFormProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    MeasureUnitId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    UFormId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFormProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UFormProducts_MeasureUnits_MeasureUnitId",
                        column: x => x.MeasureUnitId,
                        principalTable: "MeasureUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UFormProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UFormProducts_UForms_UFormId",
                        column: x => x.UFormId,
                        principalTable: "UForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_MeasureUnitId",
                table: "UFormProducts",
                column: "MeasureUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_UFormId",
                table: "UFormProducts",
                column: "UFormId");

            migrationBuilder.CreateIndex(
                name: "IX_UForms_TaxpayerStoreId",
                table: "UForms",
                column: "TaxpayerStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UFormProducts");

            migrationBuilder.DropTable(
                name: "UForms");
        }
    }
}
