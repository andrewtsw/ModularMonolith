using System;

namespace TCO.SNT.VStore.Implementation.Options
{
    public class VStoreOptions
    {
        public bool CertificateValidationEnabled { get; set; }
        public Uri BaseUrl => new Uri("https://esf.gov.kz:8443/"); // { get; set; }

        public Uri BalanceWebServiceAddress { get; set; }
        public int BalanceCurrentStatusLimit { get; set; }

        public Uri SessionWebServiceAddress { get; set; }
        public string UserNameToken { get; set; }

        public Uri TaxpayerStoreWebServiceAddress { get; set; }

        public Uri DictionariesWebServiceAddress { get; set; }
        public int GetGsvsUpdatesBlockSize { get; set; }

        public Uri UFormsWebServiceAddress { get; set; }
        public int UFormUpdatesLimit { get; set; }

        public Uri VersionWebServiceAddress { get; set; }

        public string GetBalanceWebServiceAddress() => new Uri(BaseUrl, BalanceWebServiceAddress).ToString();

        public string GetSessionWebServiceAddress() => new Uri(BaseUrl, SessionWebServiceAddress).ToString();

        public string GetTaxpayerStoreWebServiceAddress() => new Uri(BaseUrl, TaxpayerStoreWebServiceAddress).ToString();

        public string GetDictionariesWebServiceAddress() => new Uri(BaseUrl, DictionariesWebServiceAddress).ToString();

        public string GetUFormsWebServiceAddress() => new Uri(BaseUrl, UFormsWebServiceAddress).ToString();

        public string GetVersionWebServiceAddress() => new Uri(BaseUrl, VersionWebServiceAddress).ToString();
    }
}
