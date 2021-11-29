namespace TCO.SNT.Common.Serialization
{
    public class XmlMetadata
    {
        public XmlMetadata(string prefix, string ns)
        {
            Prefix = prefix;
            Namespace = ns;
        }

        public string Prefix { get; }

        public string Namespace { get; }
    }
}
