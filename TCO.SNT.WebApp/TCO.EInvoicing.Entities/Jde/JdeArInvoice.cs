using System;
using System.ComponentModel.DataAnnotations.Schema;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.EInvoicing.Entities.Jde
{
    public class JdeArInvoice : EntityBase
    {
        [Column(TypeName = "nvarchar(50)")]
        public string JdeArF03B11DocumentNumber { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string JdeArF03B11DocumentType { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string JdeArF03B11DocumentPayItem { get; set; }

        [Column(TypeName = "nvarchar(5)")]
        public string JdeArF03B11DocumentCompany { get; set; }

        public int JdeArF03B11AddressNumber { get; set; }

        public DateTime JdeArF03B11InvoiceDate { get; set; }

        public bool? JdeArF03B11VoidFlag { get; set; }

        public DateTime? JdeArF03B11UserReservedDate { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string JdeArF03B11UserReservedReference { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public DateTime? JdeArF03B11StatementDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string JdeArF03B11Reference { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string JdeArF03B11CurrencyCodeFrom { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string JdeArF03B11UnitOfMeasure { get; set; }


        public decimal JdeArF03B11Units { get; set; }

        public decimal JdeArF03B11GrossAmount { get; set; }

        public decimal JdeArF03B11NonTaxableAmount { get; set; }

        public decimal JdeArF03B11ForeignNonTaxableAmount { get; set; }

        public decimal JdeArF03B11AmountTaxable { get; set; }

        public decimal JdeArF03B11ForeignTaxableAmount { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string JdeArF03B11TaxArea { get; set; }

        public decimal JdeArF03B11TaxAmount { get; set; }

        public decimal JdeArF03B11ForeignTaxAmount { get; set; }

        public decimal JdeArF03B11CurrencyAmount { get; set; }

        public DateTime? JdeArF03B11GlDate { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string JdeArF03B11ToCurrency { get; set; }

        public DateTime? JdeArF03B11ExchangeRateEffectiveDate { get; set; }

        public decimal JdeArF03B11CurrencyConversionRate { get; set; }

        public int JdeGeneralLedgerBatchNumber { get; set; }

        public DateTime? JdeGeneralLedgerBatchDate { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string JdeGeneralLedgerBatchType { get; set; }

        public DateTime? JdeGeneralLedgerInvoiceDate { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string JdeGeneralLedgerCompany { get; set; }

        [Column(TypeName = "nvarchar(8)")]
        public string JdeGeneralLedgerAccountId { get; set; }

        [Column(TypeName = "nvarchar(29)")]
        public string JdeGeneralLedgerAccountNumberInput { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string JdeGeneralLedgerJdeLocalization { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string JdeGeneralLedgerAccountDescription { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string JdeGeneralLedgerBatchStatus { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public string JdeAddressBookTaxId { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string JdeAddressBookNameAlpha { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string JdeAddressBookTaxExemptionCertificate { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string JdeAddressBookAddressLine1 { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string JdeAddressBookAddressLine2 { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string JdeAddressBookAddressLine3 { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        public string JdeAddressBookAddressLine4 { get; set; }

        [Column(TypeName = "nvarchar(25)")]
        public string JdeAddressBookCity { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string JdeAddressBookCountry { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        public string JdeAddressBookPostalCode { get; set; }

        public decimal JdeAddressTaxRate1 { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string JdeCurrencyExchangeRateF0115CurrencyCodeFrom { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string JdeCurrencyExchangeRateF0115ToCurrency { get; set; }

        public DateTime? JdeCurrencyExchangeRateF0115ExchangeRateEffectiveDate { get; set; }

        public decimal JdeCurrencyExchangeRateF0115CurrencyConversionRate { get; set; }

        [Column(TypeName = "nvarchar(2)")]
        public string JdeGetUOMUserDefinedCode { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string JdeGetUOMUserReservedReference { get; set; }

        public string JdeGetUOMDescription { get; set; }

        public static JdeArInvoice CreateNew()
        {
            return new JdeArInvoice();
        }
    }
}
