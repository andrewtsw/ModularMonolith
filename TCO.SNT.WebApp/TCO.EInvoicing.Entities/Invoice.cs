using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Serialization;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// ЭСФ
    /// </summary>
    public class Invoice : EntityBase
    {
        public const string InvoiceV2 = "InvoiceV2";

        public const string InvoiceV1 = "InvoiceV1";

        public readonly static XmlMetadata XmlMetaData = new XmlMetadata("v2", "v2.esf");

        /// <summary>
        /// Id во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Информация о ЭСФ
        /// </summary>
        [Required]
        public InvoiceInfo InvoiceInfo { get; private set; }

        /// <summary>
        /// Направление
        /// </summary>
        public InvoiceDirection Direction { get; private set; }

        #region AbstractInvoice members

        /// <summary>
        /// Исходящий номер ЭСФ в бухгалтерии отправителя (A 1)
        /// </summary>
        [Required]
        public string Num { get; set; }

        /// <summary>
        /// Дата выписки ЭСФ (A 2)
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Дата совершения оборота (A 3)
        /// </summary>
        public DateTime TurnoverDate { get; set; }

        /// <summary>
        /// Тип ЭСФ
        /// </summary>
        public InvoiceType InvoiceType { get; set; }

        /// <summary>
        /// ФИО оператора отправившего ЭСФ
        /// </summary>
        public string OperatorFullname { get; set; }

        /// <summary>
        /// Служит для связки исправленного/дополнительного ЭСФ с основным
        /// </summary>
        public RelatedInvoice RelatedInvoice { get; set; }

        #endregion

        /// <summary>
        /// Дата выписки на бумажном носителе (2.1)
        /// </summary>
        public DateTime? DatePaper { get; set; }

        /// <summary>
        /// Причина выписки на бумажном носителе (2.1)
        /// </summary>
        public InvoicePaperReasonType? ReasonPaper { get; set; }

        /// <summary>
        /// Поставщик (B)
        /// </summary>
        public ICollection<InvoiceSeller> Sellers { get; private set; }
            = new HashSet<InvoiceSeller>();

        /// <summary>
        /// Получатель (C)
        /// </summary>
        public ICollection<InvoiceCustomer> Customers { get; private set; }
            = new HashSet<InvoiceCustomer>();

        /// <summary>
        /// Реквизиты грузоотправителя (D 25)
        /// </summary>
        [Required]
        public InvoiceConsignor Consignor { get; set; }

        /// <summary>
        /// Реквизиты грузополучателя (D 26)
        /// </summary>
        [Required]
        public InvoiceConsignee Consignee { get; set; }

        /// <summary>
        /// Условия поставки (E)
        /// </summary>
        [Required]
        public InvoiceDeliveryTerm DeliveryTerm { get; set; }

        /// <summary>
        /// Дата документа, подтверждающего поставку товаров (работ, услуг) (F 32.2)
        /// </summary>
        public DateTime? DeliveryDocDate { get; set; }

        /// <summary>
        /// Номер документа, подтверждающего поставку товаров (работ, услуг) (F 32.1)
        /// </summary>
        public string DeliveryDocNum { get; set; }

        /// <summary>
        /// Реквизиты государственного учреждения (F)
        /// </summary>
        public InvoicePublicOffice PublicOffice { get; set; }

        #region Products

        /// <summary>
        /// Товары (работы, услуги) (G)
        /// </summary>
        [Required]
        public InvoiceProductSet ProductSet { get; set; }

        public ICollection<InvoiceProduct> Products { get; private set; } = new HashSet<InvoiceProduct>();

        #endregion

        #region Seller info - I section

        /// <summary>
        /// Адрес места нахождения (I 37)
        /// </summary>
        public string SellerAgentAddress { get; set; }

        /// <summary>
        /// Документ-Дата (I 38.2)
        /// </summary>
        public string SellerAgentDocDate { get; set; }

        /// <summary>
        /// Документ-Номер (I 38.1)
        /// </summary>
        public string SellerAgentDocNum { get; set; }

        /// <summary>
        /// Поверенный (I 36)
        /// </summary>
        public string SellerAgentName { get; set; }

        /// <summary>
        /// БИН (I 35)
        /// </summary>
        public string SellerAgentTin { get; set; }

        #endregion

        #region Customer info - J section

        /// <summary>
        /// Реквизиты поверенного (оператора) покупателя. Адрес места нахождения (J 41)
        /// </summary>
        public string CustomerAgentAddress { get; set; }

        /// <summary>
        /// Документ-Дата (J 42.2)
        /// </summary>
        public string CustomerAgentDocDate { get; set; }

        /// <summary>
        /// Документ-Номер (J 42.1)
        /// </summary>
        public string CustomerAgentDocNum { get; set; }

        /// <summary>
        /// Реквизиты поверенного (оператора) покупателя. Поверенный (J 40)
        /// </summary>
        public string CustomerAgentName { get; set; }

        /// <summary>
        /// Реквизиты поверенного (оператора) покупателя. БИН (J 39)
        /// </summary>
        public string CustomerAgentTin { get; set; }

        #endregion

        /// <summary>
        /// Дополнительные сведения (K 43)
        /// </summary>
        public string AddInf { get; set; }

        public static Invoice CreateNew(long externalId, InvoiceDirection direction)
        {
            return new Invoice
            {
                ExternalId = externalId,
                Direction = direction,
                InvoiceInfo = new InvoiceInfo()
            };
        }

        public static Invoice CreateNew()
        {
            var invoice = new Invoice
            {
                InvoiceType = InvoiceType.ORDINARY_INVOICE,
                Direction = InvoiceDirection.OUTBOUND,
                InvoiceInfo = new InvoiceInfo { InvoiceStatus = InvoiceStatus.DRAFT },
                ProductSet = new InvoiceProductSet()
            };
            invoice.Sellers.Add(new InvoiceSeller());
            invoice.Customers.Add(new InvoiceCustomer());

            return invoice;
        }

        public void ValidateForEdit()
        {
            if (InvoiceInfo.InvoiceStatus != InvoiceStatus.DRAFT)
            {
                throw new ValidationException("Редактирование доступно только для ЭСФ в статусе 'Черновик'");
            }
        }

        public void ClearProducts() => Products.Clear();

        public void AddProduct(InvoiceProduct product) => Products.Add(product);

        public void FillCalculatedProductProperties()
        {
            if (!Products.IsNullOrEmpty())
            {
                FillProductProperties(Products);
                ProductSet.CalculateTotals(Products);
            }
        }

        private void FillProductProperties(IEnumerable<InvoiceProduct> products)
        {
            foreach (var product in products)
            {
                product.FillCalculatedProperties();
            }
        }

        public void UpdateUtcDates(DateTime utcNow)
        {
            InvoiceInfo.LastUpdateDateUtc = utcNow;
            InvoiceInfo.InputDateUtc = utcNow;
        }

        public void SetExternalId(long externalId)
        {
            ExternalId = externalId;
            InvoiceInfo.InvoiceStatus = InvoiceStatus.CREATED;
        }

        public void ValidateInvoiceStatus()
        {
            if (InvoiceInfo.InvoiceStatus != InvoiceStatus.DRAFT)
            {
                throw new ValidationException("Отправка в ЭСФ доступна только для счета в статусе 'Черновик'");
            }
        }

        public InvoiceCustomer GetCustomer() => Customers.Single();

        public InvoiceSeller GetSeller() => Sellers.Single();

        public bool NeedToDeliver() => 
            Direction == InvoiceDirection.INBOUND &&
            InvoiceInfo.InvoiceStatus == InvoiceStatus.CREATED;

        public bool IsInbound() => Direction == InvoiceDirection.INBOUND;

        public bool IsOutbound() => Direction == InvoiceDirection.OUTBOUND;
    }
}
