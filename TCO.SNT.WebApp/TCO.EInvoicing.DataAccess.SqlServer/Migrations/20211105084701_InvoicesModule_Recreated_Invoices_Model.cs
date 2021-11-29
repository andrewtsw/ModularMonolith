using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class InvoicesModule_Recreated_Invoices_Model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop table if exists [ei].[RelatedInvoices]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceSellers]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoicePublicOffices]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceProductSets]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceProducts]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceInfo]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceDeliveryTerms]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceCustomers]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceConsignors]");
            migrationBuilder.Sql("drop table if exists [ei].[InvoiceConsignees]");
            migrationBuilder.Sql("drop table if exists [ei].[Invoices]");

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "ei",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExternalId = table.Column<long>(nullable: true),
                    Direction = table.Column<int>(nullable: false),
                    Num = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    TurnoverDate = table.Column<DateTime>(type: "date", nullable: false),
                    InvoiceType = table.Column<int>(nullable: false),
                    OperatorFullname = table.Column<string>(nullable: true),
                    DatePaper = table.Column<DateTime>(type: "date", nullable: true),
                    ReasonPaper = table.Column<int>(nullable: true),
                    DeliveryDocDate = table.Column<DateTime>(type: "date", nullable: true),
                    DeliveryDocNum = table.Column<string>(nullable: true),
                    SellerAgentAddress = table.Column<string>(nullable: true),
                    SellerAgentDocDate = table.Column<string>(nullable: true),
                    SellerAgentDocNum = table.Column<string>(nullable: true),
                    SellerAgentName = table.Column<string>(nullable: true),
                    SellerAgentTin = table.Column<string>(nullable: true),
                    CustomerAgentAddress = table.Column<string>(nullable: true),
                    CustomerAgentDocDate = table.Column<string>(nullable: true),
                    CustomerAgentDocNum = table.Column<string>(nullable: true),
                    CustomerAgentName = table.Column<string>(nullable: true),
                    CustomerAgentTin = table.Column<string>(nullable: true),
                    AddInf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceConsignees",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    Tin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceConsignees", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceConsignees_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceConsignors",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    Tin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceConsignors", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceConsignors_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceCustomers",
                schema: "ei",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: false),
                    Tin = table.Column<string>(nullable: true),
                    BranchTin = table.Column<string>(nullable: true),
                    ReorganizedTin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShareParticipation = table.Column<decimal>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Trailer = table.Column<string>(nullable: true),
                    Statuses = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceCustomers_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDeliveryTerms",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    ContractDate = table.Column<DateTime>(type: "date", nullable: true),
                    ContractNum = table.Column<string>(nullable: true),
                    DeliveryConditionCode = table.Column<string>(nullable: true),
                    Destination = table.Column<string>(nullable: true),
                    HasContract = table.Column<bool>(nullable: false),
                    Term = table.Column<string>(nullable: true),
                    TransportTypeCode = table.Column<string>(nullable: true),
                    Warrant = table.Column<string>(nullable: true),
                    WarrantDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDeliveryTerms", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceDeliveryTerms_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceInfo",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    InvoiceBody = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(maxLength: 100, nullable: true),
                    InputDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDateUtc = table.Column<DateTimeOffset>(nullable: false),
                    SignatureValid = table.Column<bool>(nullable: false),
                    InvoiceStatus = table.Column<int>(nullable: true),
                    CancelReason = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Signature = table.Column<string>(nullable: true),
                    SignatureType = table.Column<int>(nullable: false),
                    Certificate = table.Column<string>(nullable: true),
                    Kogd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceInfo", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceInfo_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                schema: "ei",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: false),
                    ProductNumberInSnt = table.Column<string>(nullable: true),
                    TruOriginCode = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TnvedName = table.Column<string>(nullable: true),
                    UnitCode = table.Column<string>(nullable: true),
                    UnitNomenclature = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    PriceWithoutTax = table.Column<decimal>(nullable: false),
                    ExciseRate = table.Column<decimal>(nullable: true),
                    ExciseAmount = table.Column<decimal>(nullable: true),
                    TurnoverSize = table.Column<decimal>(nullable: false),
                    TurnoverAdjustment = table.Column<int>(nullable: true),
                    NdsRate = table.Column<int>(nullable: true),
                    NdsAmount = table.Column<decimal>(nullable: true),
                    TurnoverCode = table.Column<string>(nullable: true),
                    PriceWithTax = table.Column<decimal>(nullable: false),
                    ProductDeclaration = table.Column<string>(nullable: true),
                    ProductNumberInDeclaration = table.Column<string>(nullable: true),
                    CatalogTruId = table.Column<string>(nullable: true),
                    KpvedCode = table.Column<string>(nullable: true),
                    Additional = table.Column<string>(nullable: true),
                    AdditionalUnitNomenclature = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProductSets",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    CurrencyCode = table.Column<string>(nullable: true),
                    CurrencyRate = table.Column<decimal>(nullable: true),
                    NdsRateType = table.Column<int>(nullable: true),
                    TotalPriceWithoutTax = table.Column<decimal>(nullable: false),
                    TotalExciseAmount = table.Column<decimal>(nullable: true),
                    TotalTurnoverSize = table.Column<decimal>(nullable: false),
                    TotalNdsAmount = table.Column<decimal>(nullable: true),
                    TotalPriceWithTax = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceProductSets", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoiceProductSets_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePublicOffices",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    Bik = table.Column<string>(nullable: true),
                    Iik = table.Column<string>(nullable: true),
                    PayPurpose = table.Column<string>(nullable: true),
                    ProductCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePublicOffices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_InvoicePublicOffices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceSellers",
                schema: "ei",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(nullable: false),
                    Tin = table.Column<string>(nullable: true),
                    BranchTin = table.Column<string>(nullable: true),
                    ReorganizedTin = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ShareParticipation = table.Column<decimal>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CertificateSeries = table.Column<string>(nullable: true),
                    CertificateNum = table.Column<string>(nullable: true),
                    IsBranchNonResident = table.Column<bool>(nullable: true),
                    Statuses = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Trailer = table.Column<string>(nullable: true),
                    Kbe = table.Column<string>(nullable: true),
                    Iik = table.Column<string>(nullable: true),
                    Bik = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    NdscaBank = table.Column<string>(nullable: true),
                    NdscaBik = table.Column<string>(nullable: true),
                    NdscaIik = table.Column<string>(nullable: true),
                    NdscaKbe = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceSellers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceSellers_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RelatedInvoices",
                schema: "ei",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Num = table.Column<string>(nullable: true),
                    RegistrationNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatedInvoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_RelatedInvoices_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "ei",
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceCustomers_InvoiceId",
                schema: "ei",
                table: "InvoiceCustomers",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_InvoiceStatus",
                schema: "ei",
                table: "InvoiceInfo",
                column: "InvoiceStatus");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceInfo_RegistrationNumber",
                schema: "ei",
                table: "InvoiceInfo",
                column: "RegistrationNumber",
                unique: true,
                filter: "[RegistrationNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_InvoiceId",
                schema: "ei",
                table: "InvoiceProducts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ExternalId",
                schema: "ei",
                table: "Invoices",
                column: "ExternalId",
                unique: true,
                filter: "[ExternalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceSellers_InvoiceId",
                schema: "ei",
                table: "InvoiceSellers",
                column: "InvoiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceConsignees",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceConsignors",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceCustomers",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceDeliveryTerms",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceInfo",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceProducts",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceProductSets",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoicePublicOffices",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "InvoiceSellers",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "RelatedInvoices",
                schema: "ei");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "ei");
        }
    }
}
