using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Change_UFormParticipant_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormParticipant_TaxpayerStores_StoreId1",
                table: "UFormParticipant");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipant_RecipientId",
                table: "UForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipant_SenderId",
                table: "UForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFormParticipant",
                table: "UFormParticipant");

            migrationBuilder.DropIndex(
                name: "IX_UFormParticipant_StoreId1",
                table: "UFormParticipant");

            migrationBuilder.DropColumn(
                name: "StoreId1",
                table: "UFormParticipant");

            migrationBuilder.RenameTable(
                name: "UFormParticipant",
                newName: "UFormParticipants");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TaxpayerStores_ExternalId",
                table: "TaxpayerStores",
                column: "ExternalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFormParticipants",
                table: "UFormParticipants",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms",
                column: "RecipientId",
                principalTable: "UFormParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms",
                column: "SenderId",
                principalTable: "UFormParticipants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormParticipants_TaxpayerStores_StoreId",
                table: "UFormParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_RecipientId",
                table: "UForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipants_SenderId",
                table: "UForms");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TaxpayerStores_ExternalId",
                table: "TaxpayerStores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UFormParticipants",
                table: "UFormParticipants");

            migrationBuilder.DropIndex(
                name: "IX_UFormParticipants_StoreId",
                table: "UFormParticipants");

            migrationBuilder.RenameTable(
                name: "UFormParticipants",
                newName: "UFormParticipant");

            migrationBuilder.AddColumn<int>(
                name: "StoreId1",
                table: "UFormParticipant",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UFormParticipant",
                table: "UFormParticipant",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UFormParticipant_StoreId1",
                table: "UFormParticipant",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormParticipant_TaxpayerStores_StoreId1",
                table: "UFormParticipant",
                column: "StoreId1",
                principalTable: "TaxpayerStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipant_RecipientId",
                table: "UForms",
                column: "RecipientId",
                principalTable: "UFormParticipant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_UFormParticipant_SenderId",
                table: "UForms",
                column: "SenderId",
                principalTable: "UFormParticipant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
