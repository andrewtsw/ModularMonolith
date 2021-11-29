using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Rename_Warehouses_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_Warehouses_WarehouseId",
                table: "Balances");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Balances_WarehouseId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "Balances");

            migrationBuilder.AlterColumn<int>(
                name: "TaxpayerStoreId",
                table: "Balances",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "ExternalTaxpayerStoreId",
                table: "Balances",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TaxpayerStores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AlcoholLicenseId = table.Column<long>(nullable: true),
                    ExternalDocumentId = table.Column<long>(nullable: true),
                    IsCooperativeStore = table.Column<bool>(nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    IsInherited = table.Column<bool>(nullable: false),
                    IsJointStore = table.Column<bool>(nullable: false),
                    IsPostingGoods = table.Column<bool>(nullable: false),
                    IsRawMaterials = table.Column<bool>(nullable: true),
                    IsPublicStore = table.Column<bool>(nullable: true),
                    LesseeContractDate = table.Column<DateTime>(nullable: true),
                    LesseeContractNumber = table.Column<string>(nullable: true),
                    LesseeTin = table.Column<string>(nullable: true),
                    OilOvdId = table.Column<long>(nullable: true),
                    ExternalParentId = table.Column<long>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
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
                    table.PrimaryKey("PK_TaxpayerStores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxpayerStores_TaxpayerStores_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TaxpayerStores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_TaxpayerStoreId",
                table: "Balances",
                column: "TaxpayerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxpayerStores_ExternalId",
                table: "TaxpayerStores",
                column: "ExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxpayerStores_ParentId",
                table: "TaxpayerStores",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_TaxpayerStores_TaxpayerStoreId",
                table: "Balances",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_TaxpayerStores_TaxpayerStoreId",
                table: "Balances");

            migrationBuilder.DropTable(
                name: "TaxpayerStores");

            migrationBuilder.DropIndex(
                name: "IX_Balances_TaxpayerStoreId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "ExternalTaxpayerStoreId",
                table: "Balances");

            migrationBuilder.AlterColumn<long>(
                name: "TaxpayerStoreId",
                table: "Balances",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "Balances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlcoholLicenseId = table.Column<long>(type: "bigint", nullable: true),
                    DocumentId = table.Column<long>(type: "bigint", nullable: true),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false),
                    IsCooperativeStore = table.Column<bool>(type: "bit", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    IsInherited = table.Column<bool>(type: "bit", nullable: false),
                    IsJointStore = table.Column<bool>(type: "bit", nullable: false),
                    IsPostingGoods = table.Column<bool>(type: "bit", nullable: false),
                    IsRawMaterials = table.Column<bool>(type: "bit", nullable: true),
                    LesseeContractDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LesseeContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LesseeTin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OilOvdId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    PermittedTinList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsiblePersonIin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreTypeCode = table.Column<int>(type: "int", nullable: false),
                    Tin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TobaccoOvdId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Balances_WarehouseId",
                table: "Balances",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_ExternalId",
                table: "Warehouses",
                column: "ExternalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_Warehouses_WarehouseId",
                table: "Balances",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
