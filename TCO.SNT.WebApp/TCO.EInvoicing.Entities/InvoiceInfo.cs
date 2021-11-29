using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.EInvoicing.Entities
{
    /// <summary>
    /// Информация о зарегистрированном ЭСФ включая бланк
    /// </summary>
    public class InvoiceInfo
    {
        public const int RegistrationNumberMaxLength = 100;

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        /// <summary>
        /// ЭСФ (XML)
        /// </summary>
        public string InvoiceBody { get; set; }

        /// <summary>
        /// Регистрационный номер ЭСФ
        /// </summary>
        [MaxLength(RegistrationNumberMaxLength)]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Дата поступления ЭСФ в систему
        /// </summary>
        public DateTimeOffset InputDateUtc { get; set; }

        /// <summary>
        /// Дата доставки
        /// </summary>
        public DateTime? DeliveryDate { get; set; }

        /// <summary>
        /// Дата обновления ЭСФ
        /// </summary>
        public DateTimeOffset LastUpdateDateUtc { get; set; }

        /// <summary>
        /// Статус ЭЦП
        /// </summary>
        public bool SignatureValid { get; set; }

        /// <summary>
        /// Статус ЭСФ в системе
        /// </summary>
        public InvoiceStatus? InvoiceStatus { get; set; }

        /// <summary>
        /// Причина аннулирования
        /// </summary>
        public string CancelReason { get; set; }

        /// <summary>
        /// Версия ЭСФ
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Хэш
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// ЭЦП (J)
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Тип ЭЦП (J)
        /// </summary>
        public InvoiceSignatureType SignatureType { get; set; }

        /// <summary>
        /// Сертификат для проверки подписи СФ, который содержит также информацию о пользователе — владельце сертификата, который и создал ЭСФ
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Код органа государственных доходов
        /// </summary>
        public string Kogd { get; set; }
    }
}
