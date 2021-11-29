using EsfApiSdk.Awp;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCO.EInvoicing.UseCases.Awp.Models
{
    public class AwpDto
    {
        public int Id { get; set; }        

        public string RegistrationNumber { get; set; }

        public string Number { get; set; }

        public DateTime? AwpDate { get; set; }

        public DateTime? AwpSignDate { get; set; }

        public string SenderTin { get; set; }

        public string RecipientTin { get; set; }

        public AwpStatus Status { get; set; }        
    }
}
