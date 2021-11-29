using FluentDateTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.Common.Serialization;
using TCO.SNT.Entities.Exceptions;
using ValidationException =TCO.Finportal.Framework.Domain.Exceptions.ValidationException;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// СНТ
    /// </summary>
    public class Snt : EntityBase
    {
        public readonly static XmlMetadata XmlMetadata = new XmlMetadata("v1", "v1.snt");

        public readonly static int DeadlineDays = 20;

        public const int NumberMaxLen = 50;

        /// <summary>
        /// Идентификатор в ЭСФ
        /// </summary>
        public long? ExternalId { get; set; }

        /// <summary>
        /// Тип СНТ
        /// </summary>
        public SntType SntType { get; set; }

        /// <summary>
        /// Информация о СНТ
        /// </summary>
        [Required]
        public SntInfo SntInfo { get; set; }

        /// <summary>
        /// Информация о документе СНТ
        /// </summary>
        public SntDocumentInfo DocumentInfo { get; set; }

        /// <summary>
        /// Сведения о приемке товара (M)
        /// </summary>
        public SntAcceptanceGoodsInfo AcceptanceGoodsInfo { get; set; }

        /// <summary>
        /// Отметки ОГД/уполномоченного органа (организации) (N)
        /// </summary>
        public SntOgdMarksInfo OgdMarksInfo { get; set; }

        #region General section

        /// <summary>
        /// Регистрационный номер СНТ учетной системы (A 1)
        /// </summary>
        [Required]
        [MaxLength(NumberMaxLen)]
        public string Number { get; set; }

        /// <summary>
        /// Дата оформления СНТ (A 2)
        /// </summary>
        public DateTime? Date { get; set; }

        /// <summary>
        /// Дата оформления СНТ на бумажном носителе (A 2.1)
        /// </summary>
        public DateTime? DatePaper { get; set; }

        /// <summary>
        /// Причина выписки на бумажном носителе (A 2.1.1)
        /// </summary>
        public SntPaperReasonType? ReasonPaper { get; set; }

        /// <summary>
        /// Дата отгрузки товара (A 3)
        /// </summary>
        public DateTime? ShippingDate { get; set; }

        /// <summary>
        /// Регистрационный номер Акта/Уведомления по цифровой маркировке (A 4.2)
        /// </summary>
        public string DigitalMarkingNotificationNumber { get; set; }

        /// <summary>
        /// Дата Акта/Уведомления по цифровой маркировке (A 4.2.1)
        /// </summary>
        public DateTime? DigitalMarkingNotificationDate { get; set; }

        /// <summary>
        /// Регистрационный номер (исправляемой, на возврат) СНТ в ИС ЭСФ (A 5.1, A 6.1)
        /// </summary>
        public string RelatedRegistrationNumber { get; set; }

        #region SntImport - Ввоз товаров на территорию РК (A 7)

        /// <summary>
        /// Ввоз товаров на территорию РК (A 7)
        /// </summary>
        public SntImportType? ImportType { get; set; }

        /// <summary>
        /// Импорт: Код (идентификатор) территории СЭЗ (A 7.5.1)
        /// </summary>
        public long? ExternalImportSezCode { get; set; }

        #endregion

        #region SntExport - Вывоз товаров с территории РК (A 8)

        /// <summary>
        /// Вывоз товаров с территории РК (A 8)
        /// </summary>
        public SntExportType? ExportType { get; set; }

        /// <summary>
        /// Экспорт: Код (идентификатор) территории СЭЗ (A 8.5.1)
        /// </summary>
        public long? ExternalExportSezCode { get; set; }

        #endregion

        /// <summary>
        /// Перемещение товара (A 9)
        /// </summary>
        public SntTransferType? TransferType { get; set; }

        #endregion

        /// <summary>
        /// Реквизиты поставщика (B)
        /// </summary>
        [Required]
        public SntSeller Seller { get; set; }

        /// <summary>
        /// Реквизиты получателя (C)
        /// </summary>
        [Required]
        public SntCustomer Customer { get; set; }

        /// <summary>
        /// Грузополучатель (D)
        /// </summary>
        [Required]
        public SntConsignee Consignee { get; set; }

        /// <summary>
        /// Грузоотправитель (D)
        /// </summary>
        [Required]
        public SntConsignor Consignor { get; set; }

        /// <summary>
        /// Сведения по перевозке (E)
        /// </summary>
        [Required]
        public SntShippingInfo ShippingInfo { get; set; }

        /// <summary>
        /// Договор (контракт) на поставку товара (F)
        /// </summary>
        [Required]
        public SntContract Contract { get; set; }

        #region Products - Данные по товарам (G1)

        /// <summary>
        /// Данные по товарам (G1)
        /// </summary>
        public ICollection<SntProduct> Products { get; protected set; } = new HashSet<SntProduct>();

        public SntProductSet ProductSet { get; set; }

        public void AddProduct(SntProduct product)
        {
            Products.Add(product);
        }

        public void ClearProducts()
        {
            Products.Clear();
        }

        #endregion

        #region Oil products - Данные по отдельным видам нефтепродуктов (G6)

        /// <summary>
        /// Данные по отдельным видам нефтепродуктов (G6)
        /// </summary>
        public ICollection<SntOilProduct> OilProducts { get; protected set; } = new HashSet<SntOilProduct>();

        public SntOilSet OilSet { get; set; }

        public void AddOilProduct(SntOilProduct oilProduct)
        {
            OilProducts.Add(oilProduct);
        }

        public void ClearOilProducts()
        {
            OilProducts.Clear();
        }

        #endregion

        /// <summary>
        /// Данные о грузе, перевозимом на автомобильном транспорте (K)
        /// </summary>
        public SntCarCargoInfo CarCargoInfo { get; set; }

        /// <summary>
        /// Идентификатор МПТ
        /// </summary>
        public long? MptId { get; set; }

        /// <summary>
        /// Код валюты (50)
        /// </summary>
        [Required]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Курс валюты (51)
        /// </summary>
        public decimal? CurrencyRate { get; set; }

        /// <summary>
        /// Дополнительное поле - не отправляется в ЭСФ портал
        /// </summary>
        public string Comment { get; set; }

        public void SetExternalId(long externalId)
        {
            ExternalId = externalId;
            SntInfo.Status = SntStatus.CREATED;
        }

        public static Snt CreateNew(long externalId)
        {
            return new Snt
            {
                ExternalId = externalId,
                SntInfo = new SntInfo(),
                DocumentInfo = new SntDocumentInfo()
            };
        }

        public static Snt CreateNew()
        {
            return new Snt
            {
                SntType = SntType.PRIMARY_SNT,
                SntInfo = new SntInfo
                {
                    Version = SntVersion.SntV1,
                    Status = SntStatus.DRAFT,
                }
            };
        }

        public static Snt CreateCorrection()
        {
            return new Snt
            {
                SntType = SntType.FIXED_SNT,
                SntInfo = new SntInfo
                {
                    Version = SntVersion.SntV1,
                    Status = SntStatus.DRAFT,
                }
            };
        }

        public void CreateAcceptanceGoodsIfNotExists()
        {
            if (AcceptanceGoodsInfo == null)
            {
                AcceptanceGoodsInfo = new SntAcceptanceGoodsInfo();
            }
        }

        public void CreateOgdMarksInfoIfNotExists()
        {
            if (OgdMarksInfo == null)
            {
                OgdMarksInfo = new SntOgdMarksInfo();
            }
        }

        public void UpdateUtcDates(DateTime utcNow)
        {
            SntInfo.LastUpdateDateUtc = utcNow;
            SntInfo.InputDateUtc = utcNow;
        }


        public void FillCalculatedProductProperties()
        {
            if (!Products.IsNullOrEmpty())
            {
                FillProductProperties(Products);
                FillProductSet();
            }

            if (!OilProducts.IsNullOrEmpty())
            {
                FillProductProperties(OilProducts);
                FillOilProductSet();
            }
        }

        private void FillProductSet()
        {
            if (ProductSet == null)
                ProductSet = new SntProductSet();

            ProductSet.CalculateTotals(Products);
        }

        public void FillShippingInfo()
        {
            if (ShippingInfo == null)
                ShippingInfo = new SntShippingInfo();

        }

        private void FillOilProductSet()
        {
            if (OilSet == null)
                OilSet = new SntOilSet();

            OilSet.CalculateTotals(OilProducts);
        }

        private void FillProductProperties(IEnumerable<SntProductBase> products)
        {
            // ProductNumber starting from one
            var number = 1;
            foreach (var product in products)
            {
                product.ProductNumber = number.ToString();
                number++;

                product.FillCalculatedProperties();
            }
        }

        private bool IsParticipantTinRelatedTo(string tin, SntParticipant participant)
        {
            return participant != null && participant.IsRelatedToTin(tin);
        }

        public TaxpayerStore GetRelatedStore(CompanyOptions options)
        {
            // In this case we cover both Export and Inside moving (ONE_PERSON_IN_KZ)
            if (IsParticipantTinRelatedTo(options.Tin, Seller))
            {
                return Seller.TaxpayerStore;
            }

            if (IsParticipantTinRelatedTo(options.Tin, Customer))
            {
                return Customer.TaxpayerStore;
            }

            throw new EntityNotFoundException(nameof(TaxpayerStore));
        }

        public void SetStoresById(IDictionary<int, TaxpayerStore> storesById, string tin)
        {
            if (IsParticipantTinRelatedTo(tin, Seller))
            {
                Seller.SetStore(storesById[Seller.TaxpayerStoreId.Value]);
            }

            if (IsParticipantTinRelatedTo(tin, Customer))
            {
                Customer.SetStore(storesById[Customer.TaxpayerStoreId.Value]);
            }
        }

        public void SetStoresByExternalId(IDictionary<long, TaxpayerStore> storesByExternalId, string tin)
        {
            if (IsParticipantTinRelatedTo(tin, Seller))
            {
                Seller.SetStore(storesByExternalId[Seller.ExternalStoreId.Value]);
            }

            // workaround for inbound SNTs, where StoreId is not specified and petroleum products specified for example snt on test 20644203159502848 
            if (IsParticipantTinRelatedTo(tin, Customer) && Customer.ExternalStoreId.HasValue)
            {
                Customer.SetStore(storesByExternalId[Customer.ExternalStoreId.Value]);
            }
        }

        /// <summary>
        /// Входящая СНТ
        /// </summary>
        public bool IsInbound(CompanyOptions options)
        {
            return !IsOutbound(options) && Customer.IsRelatedToTin(options.Tin);
        }

        /// <summary>
        /// Исходящая СНТ
        /// </summary>
        public bool IsOutbound(CompanyOptions options)
        {
            return Seller.IsRelatedToTin(options.Tin);
        }

        /// <summary>
        /// Is Date less than specified days until deadline
        /// </summary>
        public bool IsNearDeadline(DateTime dateTimeNow, int daysUntilDeadline)
        {
            if (Date == null)
            {
                return false;
            }

            return GetDeadline() >= dateTimeNow && (dateTimeNow - GetDeadline().Value).Days <= daysUntilDeadline;
        }

        public bool IsExceedDeadline(DateTime dateTimeNow)
        {
            if (Date == null)
            {
                return false;
            }

            return GetDeadline() < dateTimeNow;
        }

        public DateTime? GetDeadline()
        {
            return Date?.AddBusinessDays(DeadlineDays - 1);
        }

        public bool IsCorrection() => SntType == SntType.FIXED_SNT;

        public void ValidateFixedSnt(Snt sntToFix)
        {
            var validationResult = new List<KeyValuePair<string, string[]>>();

            if (ShippingDate.HasValue && sntToFix.ShippingDate.HasValue &&
                ShippingDate.Value < sntToFix.ShippingDate.Value)
            {
                validationResult.Add(new KeyValuePair<string, string[]>("ShippingDate", new[] { "Дата отгрузки не должна быть раньше даты в первичной СНТ." }));
            }
            if (ImportType != sntToFix.ImportType)
            {
                validationResult.Add(new KeyValuePair<string, string[]>("ImportType", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (ExternalImportSezCode != sntToFix.ExternalImportSezCode)
            {
                validationResult.Add(new KeyValuePair<string, string[]>("ExternalImportSezCode", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (ExportType != sntToFix.ExportType)
            {
                validationResult.Add(new KeyValuePair<string, string[]>("ExportType", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (ExternalExportSezCode != sntToFix.ExternalExportSezCode)
            {
                validationResult.Add(new KeyValuePair<string, string[]>("ExternalExportSezCode", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }
            if (TransferType != sntToFix.TransferType)
            {
                validationResult.Add(new KeyValuePair<string, string[]>("TransferType", new[] { "Недоступно для редактирования в исправленой СНТ." }));
            }

            Seller.Compare("Seller", sntToFix.Seller, validationResult);
            Customer.Compare("Customer", sntToFix.Customer, validationResult);

            if (validationResult.Any())
                throw new ValidationException(validationResult);
        }

        public void ValidateForEdit()
        {
            if (SntInfo.Status != SntStatus.DRAFT)
            {
                throw new ValidationException("Редактирование доступно только для СНТ в статусе 'Черновик'");
            }
        }

        public void ValidateForCorrection()
        {
            if (SntInfo.Status != SntStatus.NOT_VIEWED &&
               SntInfo.Status != SntStatus.DELIVERED)
            {
                throw new ValidationException("Исправление СНТ доступно только для статусов \"Подтвержден\" или \"Не просмотрено\"");
            }
        }

        public bool IsFinished()
        {
            var finishedStatusList = new List<SntStatus> {
                            SntStatus.CANCELED,
                            SntStatus.CONFIRMED,
                            SntStatus.CONFIRMED_BY_OGD,
                            SntStatus.DECLINED,
                            SntStatus.DECLINED_BY_OGD,
                            SntStatus.REVOKED
                         };

            return finishedStatusList.Contains(SntInfo.Status);
        }

        public bool IsAllowedToConfirm()
        {
            var allowedToConfirmStatusList = new List<SntStatus>
                        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.CREATED,
                            SntStatus.DELIVERED
                        };

            return allowedToConfirmStatusList.Contains(SntInfo.Status);
        }

        public bool IsAllowedToRevoke()
        {
            var allowedToRevokeStatusList = new List<SntStatus>
                        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.CREATED,
                            SntStatus.DELIVERED
                        };

            return allowedToRevokeStatusList.Contains(SntInfo.Status);
        }

        public bool IsAllowedToDecline()
        {
            var allowedToDeclineStatusList = new List<SntStatus>
                        {
                            SntStatus.NOT_VIEWED,
                            SntStatus.CREATED,
                            SntStatus.DELIVERED
                        };

            return allowedToDeclineStatusList.Contains(SntInfo.Status);
        }
    }
}
