namespace TCO.Einvoicing.Jde.Implementation
{
    public class JdeApimOptions
    {
        public string AccountsReceivableScope { get; set; }

        public string SourceEnvironment { get; set; }

        public string SourceInstance { get; set; }

        public string BaseUrl { get; set; }

        public string SubscriptionKey { get; set; }

        public int JdeArRequestTimeout { get; set; }

        public string Company { get; set; }
    }
}
