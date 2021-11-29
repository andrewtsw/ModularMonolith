using AutoMapper;
using System;
using System.Globalization;
using TCO.Einvoicing.Jde.Interfaces.Models;
using TCO.EInvoicing.Entities.Jde;

namespace TCO.EInvoicing.UseCases.JdeInvoices.Mapping
{
    public class JdeAr2InvoiceDtoMappingProfile : Profile
    {
        public JdeAr2InvoiceDtoMappingProfile()
        {
            CreateMap<AccountReceivableInvoiceDto, JdeArInvoice>()
                //JdeArF03B11
                .ForMember(dest => dest.JdeArF03B11DocumentNumber, opt => opt.MapFrom(src => src.GetDocumentNumber()))
                .ForMember(dest => dest.JdeArF03B11DocumentType, opt => opt.MapFrom(src => src.GetDocumentType()))
                .ForMember(dest => dest.JdeArF03B11DocumentPayItem, opt => opt.MapFrom(src => src.GetDocumentPayItem()))
                .ForMember(dest => dest.JdeArF03B11DocumentCompany, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.DocumentCompany))
                .ForMember(dest => dest.JdeArF03B11AddressNumber, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.AddressNumber))
                .ForMember(dest => dest.JdeArF03B11InvoiceDate, opt =>
                    opt.MapFrom(src => DateTime.ParseExact(src.AccountReceivablesF03B11.InvoiceDate, "MM/dd/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.JdeArF03B11VoidFlag, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.AccountReceivablesF03B11.VoidFlag)))
                .ForMember(dest => dest.JdeArF03B11UserReservedDate, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.AccountReceivablesF03B11.UserReservedDate) ? DateTime.ParseExact(src.AccountReceivablesF03B11.UserReservedDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null))
                .ForMember(dest => dest.JdeArF03B11UserReservedReference, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.UserReservedReference))
                .ForMember(dest => dest.JdeArF03B11StatementDate, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.AccountReceivablesF03B11.StatementDate) ? DateTime.ParseExact(src.AccountReceivablesF03B11.StatementDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null))
                .ForMember(dest => dest.JdeArF03B11Reference, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.Reference))
                .ForMember(dest => dest.JdeArF03B11CurrencyCodeFrom, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.CurrencyCodeFrom))
                .ForMember(dest => dest.JdeArF03B11UnitOfMeasure, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.UnitOfMeasure))
                .ForMember(dest => dest.JdeArF03B11Units, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.Units))
                .ForMember(dest => dest.JdeArF03B11GrossAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.GrossAmount))
                .ForMember(dest => dest.JdeArF03B11NonTaxableAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.NonTaxableAmount))
                .ForMember(dest => dest.JdeArF03B11ForeignNonTaxableAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.ForeignNonTaxableAmount))
                .ForMember(dest => dest.JdeArF03B11AmountTaxable, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.AmountTaxable))
                .ForMember(dest => dest.JdeArF03B11ForeignTaxableAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.ForeignTaxableAmount))
                .ForMember(dest => dest.JdeArF03B11TaxArea, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.TaxArea))
                .ForMember(dest => dest.JdeArF03B11TaxAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.TaxAmount))
                .ForMember(dest => dest.JdeArF03B11ForeignTaxAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.ForeignTaxAmount))
                .ForMember(dest => dest.JdeArF03B11CurrencyAmount, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.CurrencyAmount))
                .ForMember(dest => dest.JdeArF03B11GlDate, opt =>
                    opt.MapFrom(src => DateTime.ParseExact(src.AccountReceivablesF03B11.GlDate, "MM/dd/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.JdeArF03B11ToCurrency, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.ToCurrency))
                .ForMember(dest => dest.JdeArF03B11ExchangeRateEffectiveDate, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.AccountReceivablesF03B11.ExchangeRateEffectiveDate) ? DateTime.ParseExact(src.AccountReceivablesF03B11.ExchangeRateEffectiveDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null))
                .ForMember(dest => dest.JdeArF03B11CurrencyConversionRate, opt => opt.MapFrom(src => src.AccountReceivablesF03B11.CurrencyConversionRate))

                //JdeGeneralLedger
                .ForMember(dest => dest.JdeGeneralLedgerBatchNumber, opt => opt.MapFrom(src => src.GeneralLedger.BatchNumber))
                .ForMember(dest => dest.JdeGeneralLedgerBatchDate, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.GeneralLedger.BatchDate) ? DateTime.ParseExact(src.GeneralLedger.BatchDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null))
                .ForMember(dest => dest.JdeGeneralLedgerBatchType, opt => opt.MapFrom(src => src.GeneralLedger.BatchType))
                .ForMember(dest => dest.JdeGeneralLedgerInvoiceDate, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.GeneralLedger.InvoiceDate) ? DateTime.ParseExact(src.GeneralLedger.InvoiceDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null))
                .ForMember(dest => dest.JdeGeneralLedgerCompany, opt => opt.MapFrom(src => src.GeneralLedger.Company))
                .ForMember(dest => dest.JdeGeneralLedgerAccountId, opt => opt.MapFrom(src => src.GeneralLedger.AccountId))
                .ForMember(dest => dest.JdeGeneralLedgerAccountNumberInput, opt => opt.MapFrom(src => src.GeneralLedger.AccountNumberInpuyt))
                .ForMember(dest => dest.JdeGeneralLedgerJdeLocalization, opt => opt.MapFrom(src => src.GeneralLedger.JdeLocalization))
                .ForMember(dest => dest.JdeGeneralLedgerAccountDescription, opt => opt.MapFrom(src => src.GeneralLedger.AccountDescription))
                .ForMember(dest => dest.JdeGeneralLedgerBatchStatus, opt => opt.MapFrom(src => src.GeneralLedger.BatchStatus))

                //JdeAddressBook
                .ForMember(dest => dest.JdeAddressBookTaxId, opt => opt.MapFrom(src => src.AddressBook.TaxId))
                .ForMember(dest => dest.JdeAddressBookNameAlpha, opt => opt.MapFrom(src => src.AddressBook.NameAlpha))
                .ForMember(dest => dest.JdeAddressBookTaxExemptionCertificate, opt => opt.MapFrom(src => src.AddressBook.TaxExemptionCertificate))
                .ForMember(dest => dest.JdeAddressBookAddressLine1, opt => opt.MapFrom(src => src.AddressBook.AddressLine1))
                .ForMember(dest => dest.JdeAddressBookAddressLine2, opt => opt.MapFrom(src => src.AddressBook.AddressLine2))
                .ForMember(dest => dest.JdeAddressBookAddressLine3, opt => opt.MapFrom(src => src.AddressBook.AddressLine3))
                .ForMember(dest => dest.JdeAddressBookAddressLine4, opt => opt.MapFrom(src => src.AddressBook.AddressLine4))
                .ForMember(dest => dest.JdeAddressBookCity, opt => opt.MapFrom(src => src.AddressBook.City))
                .ForMember(dest => dest.JdeAddressBookCountry, opt => opt.MapFrom(src => src.AddressBook.Country))
                .ForMember(dest => dest.JdeAddressBookPostalCode, opt => opt.MapFrom(src => src.AddressBook.PostalCode))

                //JdeCurrencyExchangeRateF0115
                .ForMember(dest => dest.JdeCurrencyExchangeRateF0115CurrencyCodeFrom, opt => opt.MapFrom(src => src.CurrencyExchangeRateF0115.CurrencyCodeFrom))
                .ForMember(dest => dest.JdeCurrencyExchangeRateF0115ToCurrency, opt => opt.MapFrom(src => src.CurrencyExchangeRateF0115.ToCurrency))
                .ForMember(dest => dest.JdeCurrencyExchangeRateF0115ExchangeRateEffectiveDate, opt =>
                    opt.MapFrom(src => !string.IsNullOrWhiteSpace(src.CurrencyExchangeRateF0115.ExchangeRateEffectiveDate) ? DateTime.ParseExact(src.CurrencyExchangeRateF0115.ExchangeRateEffectiveDate, "MM/dd/yyyy", CultureInfo.InvariantCulture) : (DateTime?)null))
                .ForMember(dest => dest.JdeCurrencyExchangeRateF0115CurrencyConversionRate, opt => opt.MapFrom(src => src.CurrencyExchangeRateF0115.CurrencyConversionRate))

                //JdeGetUOMU
                .ForMember(dest => dest.JdeGetUOMUserDefinedCode, opt => opt.MapFrom(src => src.GetUOM.UserDefinedCode))
                .ForMember(dest => dest.JdeGetUOMUserReservedReference, opt => opt.MapFrom(src => src.GetUOM.UserReservedReference))
                .ForMember(dest => dest.JdeGetUOMDescription, opt => opt.MapFrom(src => src.GetUOM.Description))

                //top level
                .ForMember(dest => dest.JdeAddressTaxRate1, opt => opt.MapFrom(src => src.TaxRate1))
                
                //ingore
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                ;

        }
    }
}
