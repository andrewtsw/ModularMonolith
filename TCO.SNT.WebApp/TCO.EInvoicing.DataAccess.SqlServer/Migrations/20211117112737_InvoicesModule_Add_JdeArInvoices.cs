using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCO.EInvoicing.DataAccess.SqlServer.Migrations
{
    public partial class InvoicesModule_Add_JdeArInvoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "JdeArNextPageToken",
                schema: "ei",
                table: "Settings",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "JdeArUpdatesLastDateUtc",
                schema: "ei",
                table: "Settings",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "JdeArInvoices",
                schema: "ei",
                columns: table => new
                {
                    JdeArF03B11DocumentNumber = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    JdeArF03B11DocumentType = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    JdeArF03B11DocumentPayItem = table.Column<string>(type: "nvarchar(3)", nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JdeArF03B11DocumentCompany = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    JdeArF03B11AddressNumber = table.Column<int>(nullable: false),
                    JdeArF03B11InvoiceDate = table.Column<DateTime>(nullable: false),
                    JdeArF03B11VoidFlag = table.Column<bool>(nullable: true),
                    JdeArF03B11UserReservedDate = table.Column<DateTime>(nullable: true),
                    JdeArF03B11UserReservedReference = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    JdeArF03B11StatementDate = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    JdeArF03B11Reference = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    JdeArF03B11CurrencyCodeFrom = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    JdeArF03B11UnitOfMeasure = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    JdeArF03B11Units = table.Column<decimal>(nullable: false),
                    JdeArF03B11GrossAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11NonTaxableAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11ForeignNonTaxableAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11AmountTaxable = table.Column<decimal>(nullable: false),
                    JdeArF03B11ForeignTaxableAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11TaxArea = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    JdeArF03B11TaxAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11ForeignTaxAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11CurrencyAmount = table.Column<decimal>(nullable: false),
                    JdeArF03B11GlDate = table.Column<DateTime>(nullable: true),
                    JdeArF03B11ToCurrency = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    JdeArF03B11ExchangeRateEffectiveDate = table.Column<DateTime>(nullable: true),
                    JdeArF03B11CurrencyConversionRate = table.Column<decimal>(nullable: false),
                    JdeGeneralLedgerBatchNumber = table.Column<int>(nullable: false),
                    JdeGeneralLedgerBatchDate = table.Column<DateTime>(nullable: true),
                    JdeGeneralLedgerBatchType = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    JdeGeneralLedgerInvoiceDate = table.Column<DateTime>(nullable: true),
                    JdeGeneralLedgerCompany = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    JdeGeneralLedgerAccountId = table.Column<string>(type: "nvarchar(8)", nullable: true),
                    JdeGeneralLedgerAccountNumberInput = table.Column<string>(type: "nvarchar(29)", nullable: true),
                    JdeGeneralLedgerJdeLocalization = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    JdeGeneralLedgerAccountDescription = table.Column<string>(type: "nvarchar(30)", nullable: true),
                    JdeGeneralLedgerBatchStatus = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    JdeAddressBookTaxId = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    JdeAddressBookNameAlpha = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    JdeAddressBookTaxExemptionCertificate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    JdeAddressBookAddressLine1 = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    JdeAddressBookAddressLine2 = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    JdeAddressBookAddressLine3 = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    JdeAddressBookAddressLine4 = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    JdeAddressBookCity = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    JdeAddressBookCountry = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    JdeAddressBookPostalCode = table.Column<string>(type: "nvarchar(12)", nullable: true),
                    JdeAddressTaxRate1 = table.Column<decimal>(nullable: false),
                    JdeCurrencyExchangeRateF0115CurrencyCodeFrom = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    JdeCurrencyExchangeRateF0115ToCurrency = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    JdeCurrencyExchangeRateF0115ExchangeRateEffectiveDate = table.Column<DateTime>(nullable: true),
                    JdeCurrencyExchangeRateF0115CurrencyConversionRate = table.Column<decimal>(nullable: false),
                    JdeGetUOMUserDefinedCode = table.Column<string>(type: "nvarchar(2)", nullable: true),
                    JdeGetUOMUserReservedReference = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    JdeGetUOMDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JdeArInvoices", x => new { x.JdeArF03B11DocumentNumber, x.JdeArF03B11DocumentType, x.JdeArF03B11DocumentPayItem });
                    table.UniqueConstraint("AK_JdeArInvoices_Id", x => x.Id);
                });

            migrationBuilder.UpdateData(
                schema: "ei",
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1,
                column: "JdeArUpdatesLastDateUtc",
                value: new DateTimeOffset(new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JdeArInvoices",
                schema: "ei");

            migrationBuilder.DropColumn(
                name: "JdeArNextPageToken",
                schema: "ei",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "JdeArUpdatesLastDateUtc",
                schema: "ei",
                table: "Settings");
        }
    }
}
