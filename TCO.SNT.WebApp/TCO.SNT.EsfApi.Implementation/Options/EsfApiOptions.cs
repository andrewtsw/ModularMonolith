using System;

namespace TCO.SNT.EsfApi.Implementation.Options
{
    public class EsfApiOptions
    {
        public bool CertificateValidationEnabled { get; set; }
        public Uri BaseUrl { get; set; }

        public Uri VersionWebServiceAddress { get; set; }

        public Uri DictionariesWebServiceAddress { get; set; }

        public Uri SessionWebServiceAddress { get; set; }
        public string UserNameToken { get; set; }

        public Uri SntWebServiceAddress { get; set; }
        public int SntUpdatesLimit { get; set; }

        public Uri InvoiceWebServiceAddress { get; set; }
        public int InvoiceUpdatesLimit { get; set; }

        public Uri UploadInvoiceWebServiceAddress { get; set; }

        public Uri AwpWebServiceAddress { get; set; }
        public int AwpUpdatesLimit { get; set; }


        public string GetVersionWebServiceAddress() => new Uri(BaseUrl, VersionWebServiceAddress).ToString();

        public string GetDictionariesWebServiceAddress() => new Uri(BaseUrl, DictionariesWebServiceAddress).ToString();

        public string GetSessionWebServiceAddress() => new Uri(BaseUrl, SessionWebServiceAddress).ToString();

        public string GetSntWebServiceAddress() => new Uri(BaseUrl, SntWebServiceAddress).ToString();

        public string GetInvoiceWebServiceAddress() => new Uri(BaseUrl, InvoiceWebServiceAddress).ToString();

        public string GetAwpWebServiceAddress() => new Uri(BaseUrl, AwpWebServiceAddress).ToString();

        public string GetUploadInvoiceWebServiceAddress() => new Uri(BaseUrl, UploadInvoiceWebServiceAddress).ToString();

    }
}
