using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Информация о СНТ
    /// </summary>
    public class SntInfo
    {
        public const int RegistrationNumberMaxLen = 100;

        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// Дата и время регистрации СНТ в ИС ЭСФ (A 4.1)
        /// </summary>
        public DateTimeOffset InputDateUtc { get; set; }

        /// <summary>
        /// Дата обновления СНТ
        /// </summary>
        public DateTimeOffset LastUpdateDateUtc { get; set; }

        /// <summary>
        /// Регистрационный номер СНТ в ИС ЭСФ (A 4)
        /// </summary>
        [MaxLength(RegistrationNumberMaxLen)]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Версия СНТ
        /// </summary>
        public SntVersion Version { get; set; }

        /// <summary>
        /// Статус СНТ
        /// </summary>
        public SntStatus Status { get; set; }

        /// <summary>
        /// Причина отклонения/отзыва/ошибки
        /// </summary>
        public string CancelReason { get; set; }

    }
}
