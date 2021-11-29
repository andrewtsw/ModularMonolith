using System;
using System.Text.Json.Serialization;
using TCO.SNT.Common.Errors;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.Snt.Shared
{
    public class SntSimpleDto : IWithError
    {
        public int Id { get; set; }

        public long? ExternalId { get; set; }

        public string RegistrationNumber { get; set; }

        public string Number { get; set; }

        public DateTime? Date { get; set; }

        public string SenderTin { get; set; }

        public bool SenderNonResident { get; set; }

        public string RecipientTin { get; set; }

        public bool RecipientNonResident { get; set; }

        public SntStatus Status { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public DateTime InputDate { get; set; }

        public string CancelReason { get; set; }

        public SntType SntType { get; set; }

        public int? CustomerTaxpareStoreId { get; set; }

        public int? SellerTaxpareStoreId { get; set; }

        #region IWithError

        [JsonIgnore]
        public string ErrorCode => CancelReason;

        public void SetErrorDescription(string description) => CancelReason = description;

        #endregion
    }
}
