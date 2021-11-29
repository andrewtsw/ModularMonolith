using EsfApiSdk.Invoices;
using FluentValidation;

namespace TCO.EInvoicing.UseCases.EsfInvoices.Commands.ImportInvoicesInitial
{
    internal class InvoiceInfoValidator : AbstractValidator<InvoiceInfo>
    {
        public InvoiceInfoValidator()
        {
            RuleFor(x => x.invoiceBody).NotEmpty();

            RuleFor(x => x.invoiceId).GreaterThan(0L);
            RuleFor(x => x.invoiceIdSpecified).Equal(true);

            // TODO: add other validation
        }
    }
}
