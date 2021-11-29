using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TCO.SNT.ExchangeRates.Interfaces
{
    [XmlRoot(ElementName = "item")]
    public class CurrencyRate
    {
        /// <summary>
        /// Full name (sample: АВСТРАЛИЙСКИЙ ДОЛЛАР)
        /// </summary>
        [XmlElement(ElementName = "fullname")]
        public string Fullname { get; set; }

        /// <summary>
        /// Short term (sample: AUD)
        /// </summary>
        [Required]
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// Rate (sample: 316.63) 
        /// </summary>
        [Required]
        [XmlElement(ElementName = "description")]
        public decimal Description { get; set; }

        /// <summary>
        /// Quantity (sample: 1 or 100) 
        /// </summary>
        [Required]
        [XmlElement(ElementName = "quant")]
        public decimal Quant { get; set; }

        /// <summary>
        /// Index (sample: UP/DOWN/<empty>) 
        /// </summary>
        [XmlElement(ElementName = "index")]
        public string Index { get; set; }

        /// <summary>
        /// Change (sample: +0.88 or 0.00) 
        /// </summary>
        [XmlElement(ElementName = "change")]
        public decimal Change { get; set; }

        public decimal CalculateRate() => Description / Quant;
    }
}
