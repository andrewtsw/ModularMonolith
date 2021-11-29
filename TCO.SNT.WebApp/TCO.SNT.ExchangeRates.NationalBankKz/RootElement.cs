using System.Collections.Generic;
using System.Xml.Serialization;
using TCO.SNT.ExchangeRates.Interfaces;

namespace TCO.SNT.ExchangeRates.NationalBankKz
{
    [XmlRoot(ElementName = "rates")]
    public class RootElement
    {
        [XmlElement(ElementName = "item")]
        public List<CurrencyRate> Rates { get; set; }
    }
}
