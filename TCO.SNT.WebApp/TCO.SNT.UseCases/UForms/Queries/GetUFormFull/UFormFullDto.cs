using System;
using System.Collections.Generic;
using TCO.SNT.Entities;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormFull
{
    public class UFormFullDto
    {
        public DateTime Date { get; set; }
        public string Number { get; set; }
        public UFormSenderDto Sender { get; set; }
        public UFormType Type { get; set; }
        public decimal TotalSum { get; set; }
        public List<UFormProductDto> Products { get; set; }
        public string Comment { get; set; }
        public UFormWriteOffType WriteOffReason { get; set; }
        public int RecipientTaxpayerStoreId { get; set; }
        public int UFormId { get; set; }
        public DateTime? InputDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public UFormStatusType Status { get; set; }
        public string Version { get; set; }
        public string RegistrationNumber { get; set; }
    }
}