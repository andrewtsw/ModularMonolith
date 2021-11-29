using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AlcoholLicenseId = table.Column<long>(nullable: true),
                    DocumentId = table.Column<long>(nullable: true),
                    IsCooperativeStore = table.Column<bool>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsInherited = table.Column<bool>(nullable: false),
                    IsJointStore = table.Column<bool>(nullable: false),
                    IsPostingGoods = table.Column<bool>(nullable: false),
                    IsRawMaterials = table.Column<bool>(nullable: true),
                    LesseeContractDate = table.Column<DateTime>(nullable: true),
                    LesseeContractNumber = table.Column<string>(nullable: true),
                    LesseeTin = table.Column<string>(nullable: true),
                    OilOvdId = table.Column<long>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    PermittedTinList = table.Column<string>(nullable: true),
                    ResponsiblePersonIin = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StoreName = table.Column<string>(nullable: false),
                    StoreTypeCode = table.Column<int>(nullable: false),
                    Tin = table.Column<string>(nullable: false),
                    TobaccoOvdId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalBalanceId = table.Column<long>(nullable: false),
                    Tin = table.Column<string>(nullable: false),
                    TaxpayerStoreId = table.Column<long>(nullable: false),
                    WarehouseId = table.Column<int>(nullable: false),
                    ProjectCode = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    KpvedCode = table.Column<string>(nullable: false),
                    TnvedCode = table.Column<string>(nullable: true),
                    GtinCode = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    MeasureUnitCode = table.Column<string>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    ManufactureOrImportDocNumber = table.Column<string>(nullable: true),
                    ProductNumberInImportDoc = table.Column<string>(nullable: true),
                    ProductNameInImportDoc = table.Column<string>(nullable: true),
                    PhysicalLabel = table.Column<string>(nullable: true),
                    PinCode = table.Column<string>(nullable: true),
                    SpiritPercent = table.Column<decimal>(nullable: true),
                    CanExport = table.Column<bool>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    ReserveQuantity = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_ExternalBalanceId",
                table: "Balances",
                column: "ExternalBalanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_WarehouseId",
                table: "Balances",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_ExternalId",
                table: "Warehouses",
                column: "ExternalId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
