using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.SNT.VStore.Interfaces;
using VsSdk.Dictionaries;
using DomainEntities = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Commands.ImportMeasureUnits
{
    internal class ImportMeasureUnitsCommandHandler : IRequestHandler<ImportMeasureUnitsCommand, ImportMeasureUnitsResultDto>
    {
        private readonly ISharedDbContext _context;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly IVstoreDictionariesService _vstoreDictionariesService;
        private readonly IMapper _mapper;

        public ImportMeasureUnitsCommandHandler(ISharedDbContext context,
            IVstoreSessionFactory vstoreSessionFactory,
            IVstoreDictionariesService vstoreDictionariesService,
            IMapper mapper)
        {
            _context = context;
            _vstoreSessionFactory = vstoreSessionFactory;
            _vstoreDictionariesService = vstoreDictionariesService;
            _mapper = mapper;
        }

        public async Task<ImportMeasureUnitsResultDto> Handle(ImportMeasureUnitsCommand request, CancellationToken cancellationToken)
        {
            var settings = await _context.LoadSettingsAsync(cancellationToken);

            MeasureUnitUpdatesDto updates = null;
            await using (var session = await _vstoreSessionFactory.CreateSessionAsync(cancellationToken))
            {
                updates = await _vstoreDictionariesService.GetMeasureUnitUpdatesAsync(session.SessionId,
                    settings.MeasureUnitsLastEventDateUtc.UtcDateTime);
            }

            var result = ImportMeasureUnitsResultDto.Empty();
            if (updates.Updates.Any())
            {
                updates.Updates.ValidateAll(new MeasureUnitValidator());

                if (updates.LastUpdateDateUtc.HasValue)
                {
                    settings.MeasureUnitsLastEventDateUtc = updates.LastUpdateDateUtc.Value;
                }

                var localMeasureUnitsByCode = await _context.MeasureUnits.ToDictionaryAsync(x => x.Code, cancellationToken);
                result = CreateOrUpdate(updates.Updates, localMeasureUnitsByCode);

                await _context.SaveChangesAsync(cancellationToken);
            }
            return result;
        }

        private ImportMeasureUnitsResultDto CreateOrUpdate(IReadOnlyList<MeasureUnit> externalMeasureUnits, IDictionary<string, DomainEntities.MeasureUnit> localMeasureUnitsByCode)
        {
            var result = ImportMeasureUnitsResultDto.Empty();
            foreach (var externalMeasureUnit in externalMeasureUnits)
            {
                if (!localMeasureUnitsByCode.TryGetValue(externalMeasureUnit.code, out var localMeasureUnit))
                {
                    localMeasureUnit = new DomainEntities.MeasureUnit();
                    _context.MeasureUnits.Add(localMeasureUnit);

                    result.Added++;
                }
                else
                {
                    result.Updated++;
                }
                _mapper.Map(externalMeasureUnit, localMeasureUnit);
            }

            return result;
        }
    }
}
