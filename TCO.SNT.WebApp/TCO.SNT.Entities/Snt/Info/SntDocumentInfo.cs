using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.Entities
{
    /// <summary>
    /// Информация о документе СНТ
    /// </summary>
    public class SntDocumentInfo
    {
        public int SntId { get; set; }
        public Snt Snt { get; set; }

        /// <summary>
        /// СНТ (XML)
        /// </summary>
        [Required]
        public string SntBody { get; set; }

        /// <summary>
        /// Логин пользователя, создавшего документ
        /// </summary>
        [Required]
        public string CreatorLogin { get; set; }

        /// <summary>
        /// БИН НП, создавшего документ
        /// </summary>
        [Required]
        public string CreatorTin { get; set; }

        /// <summary>
        /// Код проекта/контракта НП, создавшего документ
        /// </summary>
        public long? CreatorProjectCode { get; set; }

        /// <summary>
        /// Ф.И.О. (при его наличии) лица, выписывающего сопроводительную накладную на товары (84.3)
        /// </summary>
        [Required]
        public string SenderSignerName { get; set; }

        /// <summary>
        /// ЭЦП XML-представления СНТ
        /// </summary>
        [Required]
        public string Signature { get; set; }

        /// <summary>
        /// Тип ЭЦП, которым подписан СНТ
        /// </summary>
        public SignatureType SignatureType { get; set; }

        /// <summary>
        /// Сертификат для проверки подписи, который содержит также информацию о пользователе — владельце сертификата, который и создал документ
        /// </summary>
        [Required]
        public string Certificate { get; set; }

        /// <summary>
        /// Статус ЭЦП
        /// </summary>
        public bool SignatureValid { get; set; }

        /// <summary>
        /// Ошибки валидации (ФЛК) для данного СНТ
        /// </summary>
        public Error[] Errors { get; set; }
    }
}
