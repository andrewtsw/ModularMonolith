using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.SNT.DataAccess.SqlServer.Migrations
{
    public partial class Change_UForms_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Products_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_TaxpayerStores_TaxpayerStoreId",
                table: "UForms");

            migrationBuilder.DropTable(
                name: "EsfUFormInfos");

            migrationBuilder.DropIndex(
                name: "IX_UForms_TaxpayerStoreId",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "TaxpayerStoreId",
                table: "UForms");

            migrationBuilder.AddColumn<string>(
                name: "CancelReason",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatorLogin",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DetailingType",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderNumber",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipientId",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReorganizationType",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SignatureType",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SignatureValid",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SourceTotalSum",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UFormBody",
                table: "UForms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "UForms",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WriteOffReason",
                table: "UForms",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ProductId",
                table: "UFormProducts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MeasureUnitId",
                table: "UFormProducts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "CanExport",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DutyTypeCode",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GsvsCode",
                table: "UFormProducts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GsvsId",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufactureOrImportCountry",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManufactureOrImportDocNumber",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MeasureUnitCode",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginCertificateDate",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginCode",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhysicalLabel",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductNameInImportDoc",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductNumberInImportDoc",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SpiritPercent",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TnvedCode",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UFormId1",
                table: "UFormProducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UFormParticipant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: false),
                    AgentDocDate = table.Column<string>(nullable: true),
                    AgentDocNum = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    StoreId1 = table.Column<int>(nullable: true),
                    StoreName = table.Column<string>(nullable: false),
                    Tin = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UFormParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UFormParticipant_TaxpayerStores_StoreId1",
                        column: x => x.StoreId1,
                        principalTable: "TaxpayerStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UForms_RecipientId",
                table: "UForms",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_UForms_SenderId",
                table: "UForms",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_GsvsId",
                table: "UFormProducts",
                column: "GsvsId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId1",
                table: "UFormProducts",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_UFormId1",
                table: "UFormProducts",
                column: "UFormId1");

            migrationBuilder.CreateIndex(
                name: "IX_UFormParticipant_StoreId1",
                table: "UFormParticipant",
                column: "StoreId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts",
                column: "GsvsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Balances_ProductId1",
                table: "UFormProducts",
                column: "ProductId1",
                principalTable: "Balances",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_UForms_UFormId1",
                table: "UFormProducts",
                column: "UFormId1",
                principalTable: "UForms",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Products_GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_Balances_ProductId1",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UFormProducts_UForms_UFormId1",
                table: "UFormProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipant_RecipientId",
                table: "UForms");

            migrationBuilder.DropForeignKey(
                name: "FK_UForms_UFormParticipant_SenderId",
                table: "UForms");

            migrationBuilder.DropTable(
                name: "UFormParticipant");

            migrationBuilder.DropIndex(
                name: "IX_UForms_RecipientId",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UForms_SenderId",
                table: "UForms");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_ProductId1",
                table: "UFormProducts");

            migrationBuilder.DropIndex(
                name: "IX_UFormProducts_UFormId1",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "CancelReason",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "CreatorLogin",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "DetailingType",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "ReorganizationType",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Signature",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SignatureType",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SignatureValid",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "SourceTotalSum",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "UFormBody",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "WriteOffReason",
                table: "UForms");

            migrationBuilder.DropColumn(
                name: "CanExport",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "DutyTypeCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "GsvsCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "GsvsId",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ManufactureOrImportCountry",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ManufactureOrImportDocNumber",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "MeasureUnitCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "OriginCertificateDate",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "OriginCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "PhysicalLabel",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ProductNameInImportDoc",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "ProductNumberInImportDoc",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "SpiritPercent",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "TnvedCode",
                table: "UFormProducts");

            migrationBuilder.DropColumn(
                name: "UFormId1",
                table: "UFormProducts");

            migrationBuilder.AddColumn<int>(
                name: "TaxpayerStoreId",
                table: "UForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "UFormProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MeasureUnitId",
                table: "UFormProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EsfUFormInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorLogin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalId = table.Column<long>(type: "bigint", nullable: false),
                    InputDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Signature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignatureType = table.Column<int>(type: "int", nullable: false),
                    SignatureValid = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UFormBody = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EsfUFormInfos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UForms_TaxpayerStoreId",
                table: "UForms",
                column: "TaxpayerStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_UFormProducts_ProductId",
                table: "UFormProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EsfUFormInfos_ExternalId",
                table: "EsfUFormInfos",
                column: "ExternalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UFormProducts_Products_ProductId",
                table: "UFormProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UForms_TaxpayerStores_TaxpayerStoreId",
                table: "UForms",
                column: "TaxpayerStoreId",
                principalTable: "TaxpayerStores",
                principalColumn: "Id");
        }
    }
}
