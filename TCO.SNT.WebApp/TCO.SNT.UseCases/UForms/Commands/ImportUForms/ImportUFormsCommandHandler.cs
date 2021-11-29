using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.Common.Serialization;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.Vstore.Interfaces.UForm;
using TCO.SNT.VStore.Interfaces;
using VsSdk.UForm;

namespace TCO.SNT.UseCases.UForms.Commands.ImportUForms
{
    internal class ImportUFormsCommandHandler : IRequestHandler<ImportUFormsCommand, ImportUFormsResultDto>
    {
        private readonly IDbContext _context;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly IVstoreUFormService _vstoreUFormService;
        private readonly IMapper _mapper;
        private readonly ISharedModuleContract _sharedModuleContract;

        public ImportUFormsCommandHandler(IDbContext context,
            IVstoreSessionFactory vstoreSessionFactory,
            IVstoreUFormService vstoreUFormService,
            IMapper mapper,
            ISharedModuleContract sharedModuleContract)
        {
            _context = context;
            _vstoreSessionFactory = vstoreSessionFactory;
            _vstoreUFormService = vstoreUFormService;
            _mapper = mapper;
            _sharedModuleContract = sharedModuleContract;
        }

        public async Task<ImportUFormsResultDto> Handle(ImportUFormsCommand request, CancellationToken cancellationToken)
        {
            var settings = await _context.LoadSettingsAsync(cancellationToken);

            UFormUpdatesDto updates = null;
            await using (var session = await _vstoreSessionFactory.CreateSessionAsync(cancellationToken))
            {
                updates = await _vstoreUFormService.GetUpdatesAsync(session.SessionId,
                    settings.UFormUpdatesLastEventDateUtc.UtcDateTime);
            }

            var result = ImportUFormsResultDto.Empty();
            if (updates.Updates.Any())
            {
                var uniqueUpdates = RemoveDuplicates(updates.Updates);

                uniqueUpdates.ValidateAll(new UFormInfoValidator());

                settings.UFormUpdatesLastEventDateUtc = updates.LastEventDateUtc;
                result = await MergeAsync(uniqueUpdates, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return result;
        }

        private IReadOnlyList<UFormInfo> RemoveDuplicates(IReadOnlyList<UFormInfo> updates)
        {
            return updates
                .GroupBy(x => x.uFormId)
                // Get the latest update for the same Id
                .Select(g => g.OrderBy(x => x.lastUpdateDate).Last())
                .ToList();
        }

        private async Task<ImportUFormsResultDto> MergeAsync(IEnumerable<UFormInfo> updates, CancellationToken cancellationToken)
        {
            var storesByExternalId = await _context.GetTaxpayerStoresDictByExternalIdAsync(cancellationToken);
            var result = ImportUFormsResultDto.Empty();

            foreach (var update in updates)
            {
                var form = await _context.UForms
                    .Include(f => f.UFormInfo)
                    .TryLoadUFormByExternalIdAsync(update.uFormId, cancellationToken);

                if (form == null)
                {
                    form = Entities.UForm.CreateNew(update.uFormId);
                    _context.UForms.Add(form);

                    result.Added++;
                }
                else
                {
                    result.Updated++;
                }

                _mapper.Map(update, form.UFormInfo);

                if (form.IsNew())
                {
                    await MapUFormAsync(update.uFormBody, form, storesByExternalId, cancellationToken);
                }
            }

            return result;
        }

        public async Task MapUFormAsync(string body, Entities.UForm form,
            IDictionary<long, Entities.TaxpayerStore> storesByExternalId, CancellationToken cancellationToken)
        {
            var deserialized = SerializationHelper.DeserializeFromXml<UForm>(body);
            new UFormValidator().EnsureIsValid(deserialized);

            // Copy UForm and Abstract form fields
            _mapper.Map(deserialized, form);

            form.Sender.SetStore(storesByExternalId[form.Sender.ExternalStoreId]);
            if (form.Recipient != null)
            {
                form.Recipient.SetStore(storesByExternalId[form.Recipient.ExternalStoreId]);
            }

            await FillProductAsync(form, cancellationToken);
            // TODO: SourceProducts support will be added later
        }

        private async Task FillProductAsync(Entities.UForm form, CancellationToken cancellationToken)
        {
            foreach (var formProduct in form.Products)
            {
                var measureUnit = await _sharedModuleContract.GetMeasureUnitByCodeAsync(formProduct.ExternalMeasureUnitCode, cancellationToken);
                formProduct.SetMeasureUnit(measureUnit);

                var productCode = Entities.Product.GetGsvsCodeFromFullCode(formProduct.ExternalGsvsCode);
                var gsvs = await _context.Products
                    .SingleOrExceptionAsync(x => x.Code == productCode, cancellationToken);
                formProduct.SetProduct(gsvs);
            }
        }
    }
}
