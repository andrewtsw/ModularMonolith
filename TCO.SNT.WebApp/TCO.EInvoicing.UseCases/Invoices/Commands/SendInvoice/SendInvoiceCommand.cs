using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SendInvoice
{
    public class SendInvoiceCommand : IRequest
    {
        public SendInvoiceDto Dto { get; }
        public SendInvoiceCommand(SendInvoiceDto dto)
        {
            Dto = dto;
        }
    }
}
