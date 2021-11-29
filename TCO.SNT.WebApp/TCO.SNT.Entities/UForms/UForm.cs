using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Common.Serialization;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Универсальная Форма
    /// </summary>
    public class UForm : EntityBase
    {
        public const string UFormV1 = "UFormV1";

        public readonly static XmlMetadata XmlMetaData = new XmlMetadata("v1", "namespace.v1");

        public const int NumberMaxLen = 30;

        /// <summary>
        /// Информация о форме
        /// </summary>
        [Required]
        public UFormInfo UFormInfo { get; set; }

        /// <summary>
        /// Id во внешней системе
        /// </summary>
        public long? ExternalId { get; set; }

        #region Abstract form fields

        /// <summary>
        /// Дата выписки Универсальной Формы
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Исходящий номер Универсальной Формы в бухгалтерии отправителя
        /// </summary>
        [Required]
        [MaxLength(NumberMaxLen)]
        public string Number { get; set; }

        /// <summary>
        /// Получатель Универсальной Формы
        /// </summary>
        public UFormRecipient Recipient { get; private set; }

        public void CreateRecipientIfNotExists()
        {
            if (Recipient == null)
            {
                Recipient = new UFormRecipient();
            }
        }

        /// <summary>
        /// Отправитель Универсальной Формы
        /// </summary>
        public UFormSender Sender { get; private set; }

        public void CreateSenderIfNotExists()
        {
            if (Sender == null)
            {
                Sender = new UFormSender();
            }
        }

        /// <summary>
        /// Общая сумма
        /// </summary>
        public decimal TotalSum { get; set; }

        /// <summary>
        /// Тип Универсальной Формы
        /// </summary>
        public UFormType Type { get; set; }

        #endregion

        #region UForm fields
        /// <summary>
        /// Коментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Вид детализации
        /// </summary>
        public UFormDetailingType? DetailingType { get; set; }

        /// <summary>
        /// Номер приказа МЮ РК о реорганизации НП
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Товары
        /// </summary>
        public ICollection<UFormProduct> Products { get; protected set; } = new HashSet<UFormProduct>();

        /// <summary>
        /// Тип реорганизации
        /// </summary>
        public UFormReorganizationType? ReorganizationType { get; set; }

        /// <summary>
        /// Исходные товары универсальной Формы
        /// </summary>
        public ICollection<UFormProduct> SourceProducts { get; protected set; } = new HashSet<UFormProduct>();

        /// <summary>
        /// Общая сумма исходных товаров
        /// </summary>
        public decimal? SourceTotalSum { get; set; }

        /// <summary>
        /// Причина списания
        /// </summary>
        public UFormWriteOffType? WriteOffReason { get; set; }

        #endregion

        public void SetExternalId(long externalId)
        {
            ExternalId = externalId;
            UFormInfo.Status = UFormStatusType.CREATED;
        }

        public bool CanBeSentToEsf()
        {
            return UFormInfo.Status == UFormStatusType.DRAFT;
        }

        public static UForm CreateNew()
        {
            return new UForm
            {
                UFormInfo = new UFormInfo
                {
                    Version = UFormV1,
                    Status = UFormStatusType.DRAFT
                }
            };
        }

        public static UForm CreateNew(long externalId)
        {
            return new UForm
            {
                ExternalId = externalId,
                UFormInfo = new UFormInfo()
            };
        }

        public decimal CalculateTotal()
        {
            TotalSum = Products.Sum(x => x.CalculateTotal());

            // TotalSum should be rounded to 2 decimal places
            return TotalSum = decimal.Round(TotalSum, 2, MidpointRounding.AwayFromZero);
        }
    }
}
