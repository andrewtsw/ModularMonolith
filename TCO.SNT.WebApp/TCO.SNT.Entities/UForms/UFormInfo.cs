using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    public class UFormInfo
    {
        public const int RegistrationNumberMaxLen = 100;        

        public int UFormId { get; set; }
        public UForm UForm { get; set; }

        /// <summary>
        /// Универсальная Форма, представленная в виде XML
        /// </summary>
        public string UFormBody { get; set; }

        /// <summary>
        /// Дата поступления в систему
        /// </summary>
        public DateTimeOffset? InputDateUtc { get; set; }

        /// <summary>
        /// Дата обновления
        /// </summary>
        public DateTimeOffset? LastUpdateDateUtc { get; set; }

        /// <summary>
        /// Статус ЭЦП
        /// </summary>
        public bool? SignatureValid { get; set; }

        /// <summary>
        /// Cтатус Универсальной Формы в системе
        /// </summary>
        public UFormStatusType Status { get; set; }

        /// <summary>
        /// Причина аннулирования
        /// </summary>        
        public string CancelReason { get; set; }

        /// <summary>
        /// Версия Универсальной Формы
        /// </summary>
        [Required]
        public string Version { get; set; }

        /// <summary>
        /// ЭЦП XML-представления Формы
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Тип ЭЦП, которым подписана Форма
        /// </summary>
        public SignatureType? SignatureType { get; set; }

        /// <summary>
        /// Регистрационный номер документа
        /// </summary>
        [MaxLength(RegistrationNumberMaxLen)]
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// Логин пользователя, создавшего документ
        /// </summary>
        public string CreatorLogin { get; set; }
    }
}
