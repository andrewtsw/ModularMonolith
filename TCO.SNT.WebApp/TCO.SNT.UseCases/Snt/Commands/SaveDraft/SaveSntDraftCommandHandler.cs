using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.Extentions;

namespace TCO.SNT.UseCases.Snt.Commands.SaveDraft
{
    internal class SaveSntDraftCommandHandler : IRequestHandler<SaveSntDraftCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly UserAccessService _userAccessService;
        private readonly ISharedModuleContract _sharedModuleContract;
        private readonly CompanyOptions _companyOptions;

        public SaveSntDraftCommandHandler(IDbContext context,
            IMapper mapper,
            IDateTime dateTime,
            UserAccessService userAccessService,
            IOptions<CompanyOptions> companyOptions,
            ISharedModuleContract sharedModuleContract)
        {
            _context = context;
            _mapper = mapper;
            _dateTime = dateTime;
            _companyOptions = companyOptions.Value;
            _userAccessService = userAccessService;
            _sharedModuleContract = sharedModuleContract;
        }

        public async Task<int> Handle(SaveSntDraftCommand request, CancellationToken cancellationToken)
        {
            var snt = await LoadOrCreateSntAsync(request.Snt, cancellationToken);

            await MapSntAsync(request.Snt, snt, cancellationToken);

            await _userAccessService.ThrowIfTaxpayerStoreForbidden(snt, cancellationToken);

            if (snt.IsCorrection())
            {
                await ValidateFixedSntAsync(snt, cancellationToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return snt.Id;
        }

        private async Task ValidateFixedSntAsync(Entities.Snt snt, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(snt.RelatedRegistrationNumber))
            {
                throw new ValidationException(new[] { new KeyValuePair<string, string[]>("RelatedRegistrationNumber", new[] { "Регистрационный номер не может быть пустым." }) });
            }

            var sntToFix = await _context.LoadSntByRegistrationNumberAsync(snt.RelatedRegistrationNumber, cancellationToken);

            snt.ValidateFixedSnt(sntToFix);
        }

        private async Task<Entities.Snt> LoadOrCreateSntAsync(SntDraftDto sntDraft, CancellationToken cancellationToken)
        {
            Entities.Snt snt;

            if (sntDraft.Id.HasValue)
            {
                _userAccessService.ThrowIfUserNotAllowedToEditSntDraft();

                snt = await _context.LoadSntByIdAsync(sntDraft.Id.Value, cancellationToken);               

                snt.ValidateForEdit();

                RemoveRelatedEntities(snt);
            }
            else
            {
                await ThrowIfSntNumberDateNonUnique(sntDraft.Number, cancellationToken);

                if (!string.IsNullOrEmpty(sntDraft.RelatedRegistrationNumber))
                {
                    _userAccessService.ThrowIfUserNotAllowedToCorrectSnt();
                    await ThrowIfSntCorrectionNotAllowed(sntDraft.RelatedRegistrationNumber, cancellationToken);

                    snt = Entities.Snt.CreateCorrection();
                }
                else
                {
                    snt = Entities.Snt.CreateNew();
                }

                _context.Snts.Add(snt);
            }

            return snt;
        }

        private async Task MapSntAsync(SntDraftDto dto, Entities.Snt snt, CancellationToken cancellationToken)
        {
            _mapper.Map(dto, snt);

            if (!dto.Products.IsNullOrEmpty())
            {
                await MapProductsAsync(dto, snt, cancellationToken);
            }

            if (!dto.OilProducts.IsNullOrEmpty())
            {
                await MapOilProductsAsync(dto, snt, cancellationToken);
            }

            var storesById = await _context.GetTaxpayerStoresDictByIdAsync(cancellationToken);
            snt.SetStoresById(storesById, _companyOptions.Tin);
            snt.UpdateUtcDates(_dateTime.UtcNow);
            snt.FillCalculatedProductProperties();
        }

        private async Task MapProductsAsync(SntDraftDto dto, Entities.Snt snt, CancellationToken cancellationToken)
        {
            if (snt.IsOutbound(_companyOptions))
            {
                await MapBalancesAsync(dto, snt, cancellationToken);
            }
            else
            {
                await MapGsvsAsync(dto, snt, cancellationToken);
            }
        }

        private async Task MapGsvsAsync(SntDraftDto dto, Entities.Snt snt, CancellationToken cancellationToken)
        {
            foreach (var productDto in dto.Products)
            {
                var sntProduct = _mapper.Map<Entities.SntProduct>(productDto);
                snt.AddProduct(sntProduct);

                var gsvs = await _context.Products.FindOrExceptionAsync(productDto.GsvsId.Value, cancellationToken);
                await sntProduct.FillProductPropertiesAsync(gsvs,
                    (fixedId, cancellationToken) => _context.Products.SingleAsync(x => x.FixedId == fixedId, cancellationToken),
                    cancellationToken);

                var measureUnit = await _sharedModuleContract.GetMeasureUnitByIdAsync(productDto.MeasureUnitId.Value, cancellationToken);
                sntProduct.SetMeasureUnit(measureUnit);
            }
        }

        private async Task MapBalancesAsync(SntDraftDto dto, Entities.Snt snt, CancellationToken cancellationToken)
        {
            foreach (var productDto in dto.Products)
            {
                var sntProduct = _mapper.Map<Entities.SntProduct>(productDto);
                snt.AddProduct(sntProduct);

                var balance = await _context.Balances
                    .Include(x => x.MeasureUnit)
                    .SingleOrExceptionAsync(x => x.Id == productDto.BalanceId.Value, cancellationToken);

                sntProduct.SetBalance(balance);
            }
        }

        private async Task MapOilProductsAsync(SntDraftDto dto, Entities.Snt snt, CancellationToken cancellationToken)
        {
            foreach (var oilProductDto in dto.OilProducts)
            {
                var oilProduct = _mapper.Map<Entities.SntOilProduct>(oilProductDto);
                snt.AddOilProduct(oilProduct);

                var balance = await _context.Balances
                    .Include(x => x.MeasureUnit)
                    .SingleOrExceptionAsync(x => x.Id == oilProductDto.BalanceId, cancellationToken);

                oilProduct.SetBalance(balance);
            }
        }

        private void RemoveRelatedEntities(Entities.Snt snt)
        {
            if (snt.Products.Any())
            {
                _context.SntProducts.RemoveRange(snt.Products);
                snt.ClearProducts();
            }

            if (snt.OilProducts.Any())
            {
                _context.SntOilProducts.RemoveRange(snt.OilProducts);
                snt.ClearOilProducts();
            }
        }
        private async Task ThrowIfSntNumberDateNonUnique(string number, CancellationToken cancellationToken)
        {
            var query = _context.Snts
                .Where(x => x.Number == number && x.SntInfo.InputDateUtc.Date == _dateTime.UtcNow.Date);

            if (await query.AnyAsync(cancellationToken))
            {
                throw new ValidationException($"СНТ с таким номером и датой уже существуют, пожалуйста укажите другой номер");
            }
        }

        private async Task ThrowIfSntCorrectionNotAllowed(string relatedRegistrationNumber, CancellationToken cancellationToken = default)
        {
            var relatedSnt = await _context.LoadSntByRegistrationNumberAsync(relatedRegistrationNumber, cancellationToken);

            relatedSnt.ValidateForCorrection();

            if (!string.IsNullOrEmpty(relatedSnt.RelatedRegistrationNumber))
            {
                throw new ValidationException("Исправление уже исправленной СНТ недоступно");
            }
        }
    }
}
