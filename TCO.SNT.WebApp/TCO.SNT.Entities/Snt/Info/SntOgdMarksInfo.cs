using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Отметки ОГД/уполномоченного органа (организации) (N)
    /// </summary>
    public class SntOgdMarksInfo
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// Дата подписи данных
        /// </summary>
        public DateTimeOffset SignDateUtc { get; set; }

        /// <summary>
        /// Отметки ОГД (XML)
        /// </summary>
        [Required]
        public string SntOgdMarksBody { get; set; }

        /// <summary>
        /// ЭЦП XML-представления информации об отметках ОГД
        /// </summary>
        [Required]
        public string SntOgdMarksInfoSignature { get; set; }

        /// <summary>
        /// Тип ЭЦП, которым подписана информация об отметках ОГД
        /// </summary>
        public SignatureType SntOgdMarksInfoSignatureType { get; set; }

        /// <summary>
        /// Сертификат для проверки подписи, который содержит также информацию о пользователе — владельце сертификата, который и создал информацию об отметках ОГД
        /// </summary>
        [Required]
        public string SntOgdMarksInfoCertificate { get; set; }

        /// <summary>
        /// Статус ЭЦП
        /// </summary>
        public bool SntOgdMarksInfoSignatureValid { get; set; }

        /// <summary>
        /// Ф.И.О. сотрудника ОГД /сотрудника уполномоченного органа (организации) (N 89)
        /// </summary>
        [Required]
        public string OgdEmployeeFullName { get; set; }
    }
}
