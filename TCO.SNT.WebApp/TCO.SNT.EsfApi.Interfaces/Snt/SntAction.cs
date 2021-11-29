using EsfApiSdk.Snt;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TCO.SNT.EsfApi.Interfaces.Snt
{
    /// <summary>
    /// Тело запроса для изменения статуса СНТ
    /// </summary>
    [XmlType(Namespace = "v1.snt")]
    [XmlRoot("sntAction", Namespace = "v1.snt", IsNullable = false)]
    public class SntAction
    {
        /// <summary>
        /// Идентефикатор СНТ во внешней системе
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public long sntId { get; set; }

        /// <summary>
        /// Тип операции с СНТ
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public SntActionType actionType { get; set; }

        /// <summary>
        /// Подпись исходной СНТ
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string originalDocumentSignature { get; set; }

        /// <summary>
        /// Дата документа доверенности приемки товара
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string powerOfAttorneyDate { get; set; }

        /// <summary>
        /// Номер документа доверенности приемки товара
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string powerOfAttorneyNumber { get; set; }

        /// <summary>
        /// Причина отзыва
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string cause { get; set; }
    }
}
