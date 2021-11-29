using AutoMapper;
using EsfApiSdk.Awp;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.EsfApi.Interfaces.Awp.Models;
using TCO.SNT.Common.Serialization;
using TCO.SNT.EsfApi.Interfaces.Awp;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsInitial
{
    internal class ImportAwpsInitialCommandHandler : IRequestHandler<ImportAwpsInitialCommand, int>
    {
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfAwpService _esfAwpService;
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;

        public ImportAwpsInitialCommandHandler(IEsfApiSessionFactory esfApiSessionFactory, 
            IEsfAwpService esfAwpService,
            IEInvoicingDbContext context,
            IMapper mapper)
        {
            _esfApiSessionFactory = esfApiSessionFactory;
            _esfAwpService = esfAwpService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(ImportAwpsInitialCommand request, CancellationToken cancellationToken)
        {
            var settings = await _context.LoadSettingsAsync(cancellationToken);

            await using var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken);

            var result = 0;
            var hasUpdates = true;
            while (hasUpdates)
            {
                var updates = await _esfAwpService.GetUpdatesAsync(session.SessionId,
                    settings.AwpUpdatesLastEventDateUtc.UtcDateTime,
                    settings.AwpUpdatesLastAwpId);

                if (updates.Updates.Any())
                {
                    settings.AwpUpdatesLastEventDateUtc = updates.LastEventDateUtc;
                    settings.AwpUpdatesLastAwpId = updates.LastAwpId;

                    var awps = MapAwpInfoToAwp(updates.Updates);

                    using (var transaction = await _context.BeginTransactionAsync(cancellationToken))
                    {
                        await _context.BulkInsertEntitiesAsync(awps, cancellationToken);
                        await _context.SaveChangesAsync(cancellationToken);
                        await transaction.CommitAsync(cancellationToken);
                    }

                    result += updates.Updates.Count;
                }
                else
                {
                    hasUpdates = false;
                }
            }
            return result;
        }

        private IList<Entities.Awp> MapAwpInfoToAwp(IReadOnlyList<AwpInfo> updates)
        {
            var result = new List<Entities.Awp>(updates.Count);

            foreach (var awpInfo in updates)
            {
                var awp = Entities.Awp.CreateNew(awpInfo.awpId);
                ConstructAwp(awpInfo, awp);

                result.Add(awp);
            }
            return result;
        }

        private void ConstructAwp(AwpInfo awpInfo, Entities.Awp awp )
        {
            _mapper.Map(awpInfo, awp);

            var awpBody = SerializationHelper.DeserializeFromXml<AwpV1>(awpInfo.awpBody);

            awp.Number = awpBody.number;
            awp.AwpDate = DateTime.ParseExact(awpBody.date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            awp.AwpSignDate = DateTime.ParseExact(awpBody.performedDate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            awp.SenderTin = awpBody.senders[0]?.tin;
            awp.RecipientTin = awpBody.recipients[0]?.tin;
        }
    }
}
