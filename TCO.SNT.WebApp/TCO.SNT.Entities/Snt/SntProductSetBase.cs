using System.Collections.Generic;
using System.Linq;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Базовый класс для итоговой информации для таблицы
    /// </summary>
    public abstract class SntProductSetBase
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// Всего: Сумма акциза (52.2, 58.2, 59.2, 61.2, 63.2, 68.2, 73.2, 77.2, 78.2, 79.2)
        /// </summary>
        public decimal? TotalExciseAmount { get; set; }

        /// <summary>
        /// Всего: Сумма НДС (52.3, 58.3, 59.3, 61.3, 63.3, 68.3, 73.3, 77.3, 78.3, 79.3)
        /// </summary>
        public decimal? TotalNdsAmount { get; set; }

        /// <summary>
        /// Всего: (52.4, 58.4, 59.4, 61.4, 63.4, 68.4, 73.4, 77.4, 78.4, 79.4)
        /// </summary>
        public decimal? TotalPriceWithTax { get; set; }

        /// <summary>
        /// Всего: Стоимость реализуемого (отгружаемого) товара без косвенных налогов (52.1, 58.1, 59.1, 61.1, 63.1, 68.1, 73.1, 77.1, 78.1, 79.1)
        /// </summary>
        public decimal TotalPriceWithoutTax { get; set; }

        public void CalculateTotals(IEnumerable<SntProductBase> products)
        {
            TotalExciseAmount = products.Sum(p => p.ExciseAmount);
            TotalNdsAmount = products.Sum(p => p.NdsAmount);
            TotalPriceWithoutTax = products.Sum(p => p.PriceWithoutTax);
            TotalPriceWithTax = products.Sum(p => p.PriceWithTax);
        }
    }
}
