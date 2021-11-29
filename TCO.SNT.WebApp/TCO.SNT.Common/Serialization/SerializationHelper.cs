using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace TCO.SNT.Common.Serialization
{
    public static class SerializationHelper
    {
        public static string SerializeToXml<T>(T obj, XmlMetadata metadata)
        {
            using var textWriter = new UTF8StringWriter();
            var settings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true
            };
            using (var xmlWriter = XmlWriter.Create(textWriter, settings))
            {
                var serializer = new XmlSerializer(typeof(T));
                var xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(metadata.Prefix, metadata.Namespace);

                serializer.Serialize(xmlWriter, obj, xmlSerializerNamespaces);
                xmlWriter.Flush();
                xmlWriter.Close();
            }

            return textWriter.ToString();
        }

        public static T DeserializeFromXml<T>(string xml)
        {
            var serializer = new XmlSerializer(typeof(T));

            using var reader = new StringReader(xml);
            return (T)serializer.Deserialize(reader);
        }

        public static T DeserializeFromXml<T>(Stream xml)
        {
            xml.Position = 0;
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(xml);
        }

        private class UTF8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
