using AutoMapper;
using EsfApiSdk.Snt;
using MediatR;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Options;
using TCO.SNT.Common.Serialization;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.Snt;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.Snt.Commands.Import.Validators;

namespace TCO.SNT.UseCases.Snt.Commands.Import
{
    internal class ImportSntCommandHandler : IRequestHandler<ImportSntCommand, ImportSntResultDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfSntService _esfSntService;
        private readonly CompanyOptions _companyOptions;
        private readonly ISharedModuleContract _sharedModuleContract;

        public ImportSntCommandHandler(IDbContext context, IMapper mapper,
            IEsfApiSessionFactory esfApiSessionFactory, IEsfSntService esfSntService, IOptions<CompanyOptions> companyOptions,
            ISharedModuleContract sharedModuleContract)
        {
            _context = context;
            _mapper = mapper;
            _esfApiSessionFactory = esfApiSessionFactory;
            _esfSntService = esfSntService;
            _companyOptions = companyOptions.Value;
            _sharedModuleContract = sharedModuleContract;
        }

        public async Task<ImportSntResultDto> Handle(ImportSntCommand request, CancellationToken cancellationToken)
        {
            var settings = await _context.LoadSettingsAsync(cancellationToken);

            SntUpdatesDto updates = null;
            await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
            {
                updates = await _esfSntService.GetUpdatesAsync(session.SessionId,
                    settings.SntUpdatesLastEventDateUtc.UtcDateTime,
                    settings.SntUpdatesLastSntId);
            }

            var result = ImportSntResultDto.Empty();
            if (updates.Updates.Any())
            {
                var uniqueUpdates = RemoveDuplicates(updates.Updates);

                uniqueUpdates.ValidateAll(new SntInfoValidator());

                settings.SntUpdatesLastSntId = updates.LastSntId;
                settings.SntUpdatesLastEventDateUtc = updates.LastEventDateUtc;
                result = await MergeAsync(uniqueUpdates, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return result;
        }

        private IReadOnlyList<SntInfo> RemoveDuplicates(IReadOnlyList<SntInfo> updates)
        {
            return updates
                .GroupBy(x => x.sntId)
                // Get the latest update for the same Id
                .Select(g => g.OrderBy(x => x.lastUpdateDate).Last())
                .ToList();
        }

        private async Task<ImportSntResultDto> MergeAsync(IEnumerable<SntInfo> updates, CancellationToken cancellationToken)
        {
            // There are no 2 updates for the same SNT. So we can update existing SNT by externalId
            // Or create a new Snt if it does not exist
            var storesByExternalId = await _context.GetTaxpayerStoresDictByExternalIdAsync(cancellationToken);
            var measureUnitsByCode = await _sharedModuleContract.GetMeasureUnitsDictionaryByCodeAsync(cancellationToken);

            var result = ImportSntResultDto.Empty();
            foreach (var update in updates)
            {
                var snt = await _context.LoadSntOrDefaultByExternalIdAsync(update.sntId, cancellationToken);

                if (snt == null)
                {
                    snt = Entities.Snt.CreateNew(update.sntId);
                    _context.Snts.Add(snt);

                    result.Added++;
                }
                else
                {
                    result.Updated++;
                }

                MapSnt(snt, update);

                // No need to update sntBody for existing SNT because body is readonly.
                if (snt.IsNew())
                {
                    var sntV1 = SerializationHelper.DeserializeFromXml<SntV1>(update.documentInfo.sntBody);
                    ValidateSntModel(sntV1);

                    _mapper.Map(sntV1, snt);

                    snt.SetStoresByExternalId(storesByExternalId, _companyOptions.Tin);
                    snt.FillShippingInfo();
                    foreach (var product in snt.Products)
                    {
                        product.SetMeasureUnit(measureUnitsByCode[product.ExternalMeasureUnitCode]);
                    }

                    foreach (var oilProduct in snt.OilProducts)
                    {
                        oilProduct.SetMeasureUnit(measureUnitsByCode[oilProduct.ExternalMeasureUnitCode]);
                    }
                }
            }

            return result;
        }

        private void MapSnt(Entities.Snt snt, SntInfo update)
        {
            _mapper.Map(update, snt.SntInfo);
            _mapper.Map(update.documentInfo, snt.DocumentInfo);

            if (update.acceptanceGoodsInfo != null)
            {
                snt.CreateAcceptanceGoodsIfNotExists();
                _mapper.Map(update.acceptanceGoodsInfo, snt.AcceptanceGoodsInfo);
            }

            if (update.ogdMarksInfo != null)
            {
                snt.CreateOgdMarksInfoIfNotExists();
                _mapper.Map(update.ogdMarksInfo, snt.OgdMarksInfo);
            }
        }

        private void ValidateSntModel(SntV1 snt)
        {
            // TODO: add validators
        }
    }
}
