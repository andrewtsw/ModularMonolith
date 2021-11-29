using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntConsignee_Snts_SntId",
                table: "SntConsignee");

            migrationBuilder.DropForeignKey(
                name: "FK_SntConsignor_Snts_SntId",
                table: "SntConsignor");

            migrationBuilder.DropForeignKey(
                name: "FK_SntContract_Snts_SntId",
                table: "SntContract");

            migrationBuilder.DropForeignKey(
                name: "FK_SntCustomer_Snts_SntId",
                table: "SntCustomer");

            migrationBuilder.DropForeignKey(
                name: "FK_SntExport_Snts_SntId",
                table: "SntExport");

            migrationBuilder.DropForeignKey(
                name: "FK_SntImport_Snts_SntId",
                table: "SntImport");

            migrationBuilder.DropForeignKey(
                name: "FK_SntOilSet_Snts_SntId",
                table: "SntOilSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SntProductSet_Snts_SntId",
                table: "SntProductSet");

            migrationBuilder.DropForeignKey(
                name: "FK_SntSeller_Snts_SntId",
                table: "SntSeller");

            migrationBuilder.DropForeignKey(
                name: "FK_SntShippingInfo_Snts_SntId",
                table: "SntShippingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntShippingInfo",
                table: "SntShippingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntSeller",
                table: "SntSeller");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntProductSet",
                table: "SntProductSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntOilSet",
                table: "SntOilSet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntImport",
                table: "SntImport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntExport",
                table: "SntExport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntCustomer",
                table: "SntCustomer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntContract",
                table: "SntContract");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntConsignor",
                table: "SntConsignor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntConsignee",
                table: "SntConsignee");

            migrationBuilder.RenameTable(
                name: "SntShippingInfo",
                newName: "SntShippingInfos");

            migrationBuilder.RenameTable(
                name: "SntSeller",
                newName: "SntSellers");

            migrationBuilder.RenameTable(
                name: "SntProductSet",
                newName: "SntProductSets");

            migrationBuilder.RenameTable(
                name: "SntOilSet",
                newName: "SntOilSets");

            migrationBuilder.RenameTable(
                name: "SntImport",
                newName: "SntImports");

            migrationBuilder.RenameTable(
                name: "SntExport",
                newName: "SntExports");

            migrationBuilder.RenameTable(
                name: "SntCustomer",
                newName: "SntCustomers");

            migrationBuilder.RenameTable(
                name: "SntContract",
                newName: "SntContracts");

            migrationBuilder.RenameTable(
                name: "SntConsignor",
                newName: "SntConsignors");

            migrationBuilder.RenameTable(
                name: "SntConsignee",
                newName: "SntConsignees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntShippingInfos",
                table: "SntShippingInfos",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntSellers",
                table: "SntSellers",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntProductSets",
                table: "SntProductSets",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntOilSets",
                table: "SntOilSets",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntImports",
                table: "SntImports",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntExports",
                table: "SntExports",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntCustomers",
                table: "SntCustomers",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntContracts",
                table: "SntContracts",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntConsignors",
                table: "SntConsignors",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntConsignees",
                table: "SntConsignees",
                column: "SntId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntConsignees_Snts_SntId",
                table: "SntConsignees",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntConsignors_Snts_SntId",
                table: "SntConsignors",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntContracts_Snts_SntId",
                table: "SntContracts",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntCustomers_Snts_SntId",
                table: "SntCustomers",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntExports_Snts_SntId",
                table: "SntExports",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntImports_Snts_SntId",
                table: "SntImports",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntOilSets_Snts_SntId",
                table: "SntOilSets",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntProductSets_Snts_SntId",
                table: "SntProductSets",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntSellers_Snts_SntId",
                table: "SntSellers",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntShippingInfos_Snts_SntId",
                table: "SntShippingInfos",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SntConsignees_Snts_SntId",
                table: "SntConsignees");

            migrationBuilder.DropForeignKey(
                name: "FK_SntConsignors_Snts_SntId",
                table: "SntConsignors");

            migrationBuilder.DropForeignKey(
                name: "FK_SntContracts_Snts_SntId",
                table: "SntContracts");

            migrationBuilder.DropForeignKey(
                name: "FK_SntCustomers_Snts_SntId",
                table: "SntCustomers");

            migrationBuilder.DropForeignKey(
                name: "FK_SntExports_Snts_SntId",
                table: "SntExports");

            migrationBuilder.DropForeignKey(
                name: "FK_SntImports_Snts_SntId",
                table: "SntImports");

            migrationBuilder.DropForeignKey(
                name: "FK_SntOilSets_Snts_SntId",
                table: "SntOilSets");

            migrationBuilder.DropForeignKey(
                name: "FK_SntProductSets_Snts_SntId",
                table: "SntProductSets");

            migrationBuilder.DropForeignKey(
                name: "FK_SntSellers_Snts_SntId",
                table: "SntSellers");

            migrationBuilder.DropForeignKey(
                name: "FK_SntShippingInfos_Snts_SntId",
                table: "SntShippingInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntShippingInfos",
                table: "SntShippingInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntSellers",
                table: "SntSellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntProductSets",
                table: "SntProductSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntOilSets",
                table: "SntOilSets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntImports",
                table: "SntImports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntExports",
                table: "SntExports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntCustomers",
                table: "SntCustomers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntContracts",
                table: "SntContracts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntConsignors",
                table: "SntConsignors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SntConsignees",
                table: "SntConsignees");

            migrationBuilder.RenameTable(
                name: "SntShippingInfos",
                newName: "SntShippingInfo");

            migrationBuilder.RenameTable(
                name: "SntSellers",
                newName: "SntSeller");

            migrationBuilder.RenameTable(
                name: "SntProductSets",
                newName: "SntProductSet");

            migrationBuilder.RenameTable(
                name: "SntOilSets",
                newName: "SntOilSet");

            migrationBuilder.RenameTable(
                name: "SntImports",
                newName: "SntImport");

            migrationBuilder.RenameTable(
                name: "SntExports",
                newName: "SntExport");

            migrationBuilder.RenameTable(
                name: "SntCustomers",
                newName: "SntCustomer");

            migrationBuilder.RenameTable(
                name: "SntContracts",
                newName: "SntContract");

            migrationBuilder.RenameTable(
                name: "SntConsignors",
                newName: "SntConsignor");

            migrationBuilder.RenameTable(
                name: "SntConsignees",
                newName: "SntConsignee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntShippingInfo",
                table: "SntShippingInfo",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntSeller",
                table: "SntSeller",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntProductSet",
                table: "SntProductSet",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntOilSet",
                table: "SntOilSet",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntImport",
                table: "SntImport",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntExport",
                table: "SntExport",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntCustomer",
                table: "SntCustomer",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntContract",
                table: "SntContract",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntConsignor",
                table: "SntConsignor",
                column: "SntId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SntConsignee",
                table: "SntConsignee",
                column: "SntId");

            migrationBuilder.AddForeignKey(
                name: "FK_SntConsignee_Snts_SntId",
                table: "SntConsignee",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntConsignor_Snts_SntId",
                table: "SntConsignor",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntContract_Snts_SntId",
                table: "SntContract",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntCustomer_Snts_SntId",
                table: "SntCustomer",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntExport_Snts_SntId",
                table: "SntExport",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntImport_Snts_SntId",
                table: "SntImport",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntOilSet_Snts_SntId",
                table: "SntOilSet",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntProductSet_Snts_SntId",
                table: "SntProductSet",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntSeller_Snts_SntId",
                table: "SntSeller",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SntShippingInfo_Snts_SntId",
                table: "SntShippingInfo",
                column: "SntId",
                principalTable: "Snts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
