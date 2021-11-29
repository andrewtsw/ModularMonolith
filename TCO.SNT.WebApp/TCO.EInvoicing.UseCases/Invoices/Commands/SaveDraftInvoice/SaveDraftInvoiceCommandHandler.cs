using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.UseCases.Extensions;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice
{
    internal class SaveDraftInvoiceCommandHandler : IRequestHandler<SaveDraftInvoiceCommand, int>
    {
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;
        private readonly CompanyOptions _options;
        private readonly ISharedModuleContract _sharedModuleContract;

        public SaveDraftInvoiceCommandHandler(IEInvoicingDbContext context,
            IMapper mapper, IDateTime dateTime, IOptions<CompanyOptions> options, ISharedModuleContract sharedModuleContract)
        {
            _context = context;
            _mapper = mapper;
            _dateTime = dateTime;
            _options = options.Value;
            _sharedModuleContract = sharedModuleContract;
        }

        public async Task<int> Handle(SaveDraftInvoiceCommand request, CancellationToken cancellationToken)
        {
            var invoice = await LoadOrCreateInvoiceAsync(request.Dto.Id, cancellationToken);

            await MapInvoiceAsync(request.Dto, invoice, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return invoice.Id;
        }

        private async Task MapInvoiceAsync(InvoiceDto dto, Invoice invoice, CancellationToken cancellationToken)
        {
            _mapper.Map(dto, invoice);
            _mapper.Map(dto.Customer, invoice.GetCustomer());

            _mapper.Map(dto.Seller, invoice.GetSeller());
            invoice.GetSeller().FillCompanyOptions(_options);

            invoice.ProductSet.Update(dto.CurrencyCode, dto.CurrencyRate, dto.NdsRateType);
            if (!dto.Products.IsNullOrEmpty())
            {
                await MapProductsAsync(dto, invoice, cancellationToken);
            }

            invoice.UpdateUtcDates(_dateTime.UtcNow);
            invoice.FillCalculatedProductProperties();
        }

        private async Task MapProductsAsync(InvoiceDto dto, Invoice invoice, CancellationToken cancellationToken)
        {
            foreach (var productDto in dto.Products)
            {
                var product = _mapper.Map<InvoiceProduct>(productDto);
                invoice.AddProduct(product);

                var unit  = await _sharedModuleContract.GetMeasureUnitByIdAsync(productDto.MeasureUnitId, cancellationToken);

                product.SetMeasureUnit(unit);
                product.SetCatalogTruId();
            }
        }

        private async Task<Invoice> LoadOrCreateInvoiceAsync(int? id, CancellationToken cancellationToken)
        {
            Invoice invoice;

            if (id.HasValue)
            {
                invoice = await _context.LoadInvoiceByIdAsync(id.Value, cancellationToken);

                invoice.ValidateForEdit();

                RemoveRelatedEntities(invoice);
            }
            else
            {
                invoice = Invoice.CreateNew();

                _context.Invoices.Add(invoice);
            }

            return invoice;
        }

        private void RemoveRelatedEntities(Invoice invoice)
        {
            if (invoice.Products.Any())
            {
                _context.InvoiceProducts.RemoveRange(invoice.Products);
                invoice.ClearProducts();
            }
        }
    }
}
