using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Change_UFormParticipants_Store_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormParticipants_TaxpayerStores_StoreId",
                table: "UFormParticipants");

            migrationBuilder.DropIndex(
                name: "IX_UFormParticipants_StoreId",
                table: "UFormParticipants");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TaxpayerStores_ExternalId",
                table: "TaxpayerStores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "UFormParticipants");

            migrationBuilder.AddColumn<long>(
                name: "ExternalStoreId",
                table: "UFormParticipants",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "TaxpayerStoreId",
                table: "UFormParticipants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UFormParticipants_TaxpayerStoreId",
                table: "UFormParticipants",
                column: "TaxpayerStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormParticipants_TaxpayerStores_TaxpayerStoreId",
                table: "UFormParticipants",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormParticipants_TaxpayerStores_TaxpayerStoreId",
                table: "UFormParticipants");

            migrationBuilder.DropIndex(
                name: "IX_UFormParticipants_TaxpayerStoreId",
                table: "UFormParticipants");

            migrationBuilder.DropColumn(
                name: "ExternalStoreId",
                table: "UFormParticipants");

            migrationBuilder.DropColumn(
                name: "TaxpayerStoreId",
                table: "UFormParticipants");

            migrationBuilder.AddColumn<long>(
                name: "StoreId",
                table: "UFormParticipants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TaxpayerStores_ExternalId",
                table: "TaxpayerStores",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormParticipants_StoreId",
                table: "UFormParticipants",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormParticipants_TaxpayerStores_StoreId",
                table: "UFormParticipants",
                column: "StoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "ExternalId");
        }
    }
}
