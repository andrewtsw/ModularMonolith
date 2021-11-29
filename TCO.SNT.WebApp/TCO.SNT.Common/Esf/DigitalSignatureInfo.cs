namespace TCO.SNT.Common.Esf
{
    public class DigitalSignatureInfo
    {
        public DigitalSignatureInfo(string body, string signature, string certificate)
        {
            Body = body;
            Signature = signature;
            Certificate = certificate;
        }

        public string Body { get; }

        public string Signature { get; }

        public string Certificate { get; }
    }
}
