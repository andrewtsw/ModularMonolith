using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.UForms.Commands.Dto;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases.Extensions;

namespace TCO.SNT.UseCases.UForms.Commands
{
    internal abstract class SaveUFormCommandHandlerBase
    {
        protected readonly IDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly CompanyOptions _companyOptions;
        private readonly UserAccessService _userAccessService;

        protected SaveUFormCommandHandlerBase(IDbContext context, IMapper mapper, IOptions<CompanyOptions> companyOptions, UserAccessService userAccessService)
        {
            _context = context;
            _mapper = mapper;
            _companyOptions = companyOptions.Value;
            _userAccessService = userAccessService;
        }

        protected async Task<int> HandleBase(UFormDtoBase dto, CancellationToken cancellationToken)
        {
            UForm form = null;
            if (dto.Id.HasValue)
            {
                form = await _context.UForms
                    .AddUFormIncludes()
                    .SingleOrExceptionAsync(x => x.Id == dto.Id.Value, cancellationToken);

                _userAccessService.ThrowIfUserNotAllowedToCorrectUformDraft(form.Type, form.UFormInfo.Status);
                await _userAccessService.ThrowIfTaxpayerStoreForbidden(form, cancellationToken);

                _context.UFormProducts.RemoveRange(form.Products);
                form.Products.Clear();
            }
            else
            {
                form = UForm.CreateNew();
                form.Type = dto.GetUFormType();
                _context.UForms.Add(form);
            }

            await MapUFormFieldsAsync(dto, form, cancellationToken);

            await MapProductsAsync(dto.GetProducts(), form, cancellationToken);

            form.CalculateTotal();

            await _context.SaveChangesAsync(cancellationToken);

            return form.Id;
        }

        protected virtual Task MapUFormFieldsAsync(UFormDtoBase dto, UForm form, CancellationToken cancellationToken)
        {
            dto.FillForm(form);

            form.CreateSenderIfNotExists();
            return MapUFormParticipantAsync(dto.SenderTaxpayerStoreId, form.Sender, cancellationToken);
        }

        protected async Task MapUFormParticipantAsync(int taxpayerStoreId, UFormParticipant participant, CancellationToken cancellationToken)
        {
            participant.FillCompanyOptions(_companyOptions);
            participant.ClearAgentDoc();

            var store = await _context.TaxpayerStores
                .SingleOrExceptionAsync(x => x.Id == taxpayerStoreId, cancellationToken);
            participant.FillStore(store);
        }

        private async Task MapProductsAsync(IEnumerable<UFormProductDtoBase> products, UForm form, CancellationToken cancellationToken)
        {
            foreach (var productDto in products)
            {
                var formProduct = new UFormProduct();
                form.Products.Add(formProduct);

                formProduct.Price = productDto.Price;
                formProduct.Quantity = productDto.Quantity;

                await MapUFormProductAsync(form, productDto, formProduct, cancellationToken);
            }
        }

        protected abstract Task MapUFormProductAsync(UForm form, UFormProductDtoBase productDtoBase,
            UFormProduct formProduct, CancellationToken cancellationToken);

        protected async Task MapBalanceAsync(UForm form, int balanceId,
            UFormProduct formProduct, CancellationToken cancellationToken)
        {
            var balance = await _context.Balances
                .Include(x => x.MeasureUnit)
                .SingleOrExceptionAsync(x => x.Id == balanceId, cancellationToken);
            if (balance.TaxpayerStoreId != form.Sender.TaxpayerStoreId)
            {
                throw new ValidationException("Некорректный склад");
            }
            if (balance.Quantity - formProduct.Quantity < 0m)
            {
                throw new ValidationException("Недостаточно товара на складе");
            }
            formProduct.FillBalance(balance);
        }

        protected async Task FillGsvsCodeAsync(UFormProduct formProduct, CancellationToken cancellationToken)
        {
            Product gtin = null;
            Product tnved = null;
            Product kpved = null;
            if (formProduct.Product.GsvsTypeCode == GsvsType.GTIN)
            {
                gtin = formProduct.Product;
                tnved = await _context.Products.SingleOrExceptionAsync(x => x.FixedId == gtin.FixedParentId, cancellationToken);
            }
            else if (formProduct.Product.GsvsTypeCode == GsvsType.TNVED)
            {
                tnved = formProduct.Product;
            }

            kpved = await _context.Products.SingleOrExceptionAsync(x => x.FixedId == tnved.FixedParentId, cancellationToken);
            formProduct.SetProductCodes(kpved, tnved, gtin);
        }
    }
}
