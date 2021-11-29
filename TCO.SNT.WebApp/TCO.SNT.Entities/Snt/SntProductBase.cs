using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Entities;
using EntityNotFoundException = TCO.Finportal.Framework.Domain.Exceptions.EntityNotFoundException;
using ValidationException = TCO.Finportal.Framework.Domain.Exceptions.ValidationException;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Базования информация о товаре
    /// </summary>
    public abstract class SntProductBase : EntityBase
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// Номер товарной позиции в СНТ (G1 1, G2 1, G3 1, G4 1, G5 1, G6 1, G7 1, G8 1, G9 1, G10 1)
        /// </summary>
        [Required]
        public string ProductNumber { get; set; }

        /// <summary>
        /// Признак происхождения товара (G1 2, G2 2, G3 2, G4 2, G5 2, G6 2, G7 2, G8 2, G9 2, G10 2)
        /// </summary>
        [Required]
        public int TruOriginCode { get; set; }

        /// <summary>
        /// Код товара (ТН ВЭД ЕАЭС) (G1 4, G2 5, G3 5, G4 5, G5 5, G6 5, G7 4, G8 5, G9 5, G10 7)
        /// </summary>
        [Required]
        public string TnvedCode { get; protected set; }

        /// <summary>
        /// Стоимость товара без косвенных налогов (G1 8, G2 8, G3 8, G4 12, G5 11, G6 9, G7 8, G8 11, G9 8, G10 11)
        /// </summary>
        public decimal PriceWithoutTax { get; set; }

        /// <summary>
        /// Ставка акциза (G1 9/1, G2 9/2, G3 9/1, G4 13/1, G5 12/2, G6 10/1, G7 9/1, G8 12/1, G9 9/1, G10 12/1)
        /// </summary>
        public decimal? ExciseRate { get; set; }

        /// <summary>
        /// Сумма акциза (G1 9, G2 9, G3 9, G4 13, G5 12, G6 10, G7 9, G8 12, G9 9, G10 12)
        /// </summary>
        public decimal? ExciseAmount { get; set; }

        /// <summary>
        /// Ставка НДС (G1 10, G2 10, G3 10, G4 14, G5 13, G6 11, G7 10, G8 13, G9 10, G10 13)
        /// </summary>
        public int? NdsRate { get; set; }

        /// <summary>
        /// Сумма НДС (G1 11, G2 11, G3 11, G4 15, G5 14, G6 12, G7 11, G8 14, G9 11, G10 14)
        /// </summary>
        public decimal? NdsAmount { get; set; }

        /// <summary>
        /// Общая стоимость  товара с косвенными налогами (G1 12, G2 12, G3 12, G4 16, G5 15, G6 13, G7 12, G8 15, G9 12, G10 15)
        /// </summary>
        public decimal PriceWithTax { get; set; }

        /// <summary>
        /// Идентификатор товара в ИС ЭСФ  (G1 13, G2 13, G3 13, G4 17, G5 15, G6 14, G7 13, G8 16, G9 13, G10 16)
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// № заявления о выпуске товаров до подачи декларации на товары, заявления о ввозе товаров и уплате косвенных налогов, СТ-1 или СТ-KZ, первичной СНТ (G1 14, G2 14, G3 14, G4 18, G5 16, G6 15, G7 14, G8 17, G9 14, G10 17)
        /// </summary>
        public string DeclarationNumberForSnt { get; set; }

        /// <summary>
        /// Номер товарной позиции из заявления о выпуске товаров до подачи декларации на товары , о ввозе товаров и уплате косвенных налогов или Декларации на товары, первичной СНТ (G1 15, G2 15, G3 15, G4 19, G5 17, G6 16, G7 15, G8 18, G9 15, G10 18)
        /// </summary>
        public string ProductNumberInDeclaration { get; set; }

        /// <summary>
        /// Дополнительная информация (G1 17, G2 17, G3 17, G4 21, G5 19, G6 17, G7 16, G8 20, G9 16, G10 19)
        /// </summary>
        public string AdditionalInfo { get; set; }

        public int? MeasureUnitId { get; set; }
        public MeasureUnit MeasureUnit { get; set; }

        public void SetMeasureUnit(MeasureUnit unit)
        {
            MeasureUnit = unit;
            MeasureUnitId = unit.Id;
            UpdateExternalMeasureUnitCode(unit.Code);
        }

        protected abstract void UpdateExternalMeasureUnitCode(string code);

        public int? BalanceId { get; set; }
        public Balance Balance { get; set; }

        public int? GsvsId { get; set; }
        public Product Gsvs { get; set; }

        public virtual void SetBalance(Balance balance)
        {
            Balance = balance;
            BalanceId = balance.Id;

            TnvedCode = balance.TnvedCode;
            ProductId = $"{balance.GetFullProductCode()}<{balance.ProductId}>";
            if (!string.IsNullOrEmpty(balance.PinCode))
            {
                ProductId += $"{{{balance.PinCode}}}";
            }

            SetMeasureUnit(balance.MeasureUnit);
        }

        public delegate Task<Product> LoadGsvsByFixedIdAsync(long fixedId, CancellationToken cancellationToken);

        public async Task FillProductPropertiesAsync(Product gsvs, LoadGsvsByFixedIdAsync loadTnvedDelegate, CancellationToken cancellationToken)
        {
            if (!gsvs.IsAvailableForSnt())
                throw new ValidationException();

            if (gsvs.GsvsTypeCode == GsvsType.TNVED)
            {
                TnvedCode = gsvs.Code;
            }
            else
            {
                var tnved = await loadTnvedDelegate(gsvs.FixedParentId, cancellationToken);
                TnvedCode = tnved.Code;
            }
            Gsvs = gsvs;
            GsvsId = gsvs.Id;
        }

        public void FillCalculatedProperties()
        {
            PriceWithoutTax = GetPrice * GetQuantity;
            if (ExciseRate.HasValue)
                ExciseAmount = ExciseRate.Value * GetQuantity;
            if (NdsRate.HasValue)
                NdsAmount = NdsRate.Value * (PriceWithoutTax + ExciseAmount);
            PriceWithTax = PriceWithoutTax + (ExciseAmount ?? 0m) + (NdsAmount ?? 0m);
        }

        public long GetBalanceProductIdOrException()
        {
            // productId comes from ESF in "08.91.12.01-2503001000<812004>" format so we need number between '<' and '>'. 
            // This is unique products batch number(or [dbo].[Balances].[ProductId]). 
            if (ProductId.Contains("<") && ProductId.Contains(">"))
            {
                return long.Parse(ProductId.Split("<")[1].Split(">")[0]);
            }

            throw new EntityNotFoundException("ProductId");
        }

        protected abstract decimal GetPrice { get; }

        protected abstract decimal GetQuantity { get; }

        public decimal CalculateTotal()
        {
            return GetQuantity * GetPrice;
        }
    }
}
