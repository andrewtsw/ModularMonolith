using System.Xml.Serialization;

namespace TCO.SNT.EsfIntegration.Shared.Security
{
    public class Password
    {
        public Password()
        {
            Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText";
        }

        public Password(string value) : this()
        {
            Value = value;
        }

        [XmlAttribute]
        public string Type { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
