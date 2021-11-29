using System;
using System.Collections.Generic;
using System.Linq;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Данные по товарам, работам, услугам (G)
    /// </summary>
    public class InvoiceProductSet
    {
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// Код валюты (G 33.1)
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Курс валюты (G 33.2)
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Тип НДС ('Без НДС – не РК')
        /// </summary>
        public InvoiceNdsRateType? NdsRateType { get; set; }

        /// <summary>
        /// Итоговая стоимость ТРУ без учета НДС (G 8)
        /// </summary>
        public decimal TotalPriceWithoutTax { get; set; }

        /// <summary>
        /// Итоговая Акциз-Сумма (G 10)
        /// </summary>
        public decimal? TotalExciseAmount { get; set; }

        /// <summary>
        /// Итоговый размер оборота по реализации (G 11)
        /// </summary>
        public decimal TotalTurnoverSize { get; set; }

        /// <summary>
        /// Итоговая НДС-Сумма (G 13)
        /// </summary>
        public decimal? TotalNdsAmount { get; set; }

        /// <summary>
        /// Итоговая стоимость ТРУ с учетом НДС (G 14)
        /// </summary>
        public decimal TotalPriceWithTax { get; set; }

        public void CalculateTotals(ICollection<InvoiceProduct> products)
        {
            TotalPriceWithoutTax = products.Sum(p => p.PriceWithoutTax);
            TotalExciseAmount = products.Sum(p => p.ExciseAmount);
            TotalTurnoverSize = products.Sum(p => p.TurnoverSize);
            TotalNdsAmount = products.Sum(p => p.NdsAmount);
            TotalPriceWithTax = products.Sum(p => p.PriceWithTax);
        }

        public void Update(string currencyCode, decimal? currencyRate, InvoiceNdsRateType? ndsRateType)
        {
            CurrencyCode = currencyCode;
            CurrencyRate = currencyRate;
            NdsRateType = ndsRateType;
        }
    }
}
