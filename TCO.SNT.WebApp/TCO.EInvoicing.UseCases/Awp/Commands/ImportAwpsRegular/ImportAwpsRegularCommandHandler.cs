using AutoMapper;
using EsfApiSdk.Awp;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.EsfApi.Interfaces.Awp.Models;
using TCO.SNT.Common.Serialization;
using TCO.SNT.EsfApi.Interfaces.Awp;
using TCO.SNT.EsfApi.Interfaces.Session;

namespace TCO.EInvoicing.UseCases.Awp.Commands.ImportAwpsRegular
{
    internal class ImportAwpsRegularCommandHandler : IRequestHandler<ImportAwpsRegularCommand, ImportAwpsResultDto>
    {
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfAwpService _esfAwpService;
        private readonly IEInvoicingDbContext _context;
        private readonly IMapper _mapper;

        public ImportAwpsRegularCommandHandler(IEsfApiSessionFactory esfApiSessionFactory,
            IEsfAwpService esfAwpService,
            IEInvoicingDbContext context,
            IMapper mapper)
        {
            _esfApiSessionFactory = esfApiSessionFactory;
            _esfAwpService = esfAwpService;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ImportAwpsResultDto> Handle(ImportAwpsRegularCommand request, CancellationToken cancellationToken)
        {
            if (!await _context.Awps.AnyAsync(cancellationToken))
            {
                throw new InvalidOperationException("Can not run ImportAwpsRegularCommand because there are no Awps in the DB ");
            }

            var settings = await _context.LoadSettingsAsync(cancellationToken);
            
            AwpUpdatesDto updates;
            await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
            {
                updates = await _esfAwpService.GetAllUpdatesAsync(session.SessionId,
                    settings.AwpUpdatesLastEventDateUtc.UtcDateTime,
                    settings.AwpUpdatesLastAwpId);
            }

            var result = ImportAwpsResultDto.Empty();

            if (updates.Updates.Any())
            {
                settings.AwpUpdatesLastEventDateUtc = updates.LastEventDateUtc;
                settings.AwpUpdatesLastAwpId = updates.LastAwpId;

                result = await MergeAsync(updates, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
            }
            return result;
        }

        private async Task<ImportAwpsResultDto> MergeAsync(AwpUpdatesDto updates, CancellationToken cancellationToken)
        {
            var result = ImportAwpsResultDto.Empty();

            foreach (var awpInfo in updates.Updates)
            {
                var awp = await _context.Awps.SingleOrDefaultAsync(a => a.ExternalId == awpInfo.awpId, cancellationToken);

                if (awp == null)
                {
                    awp = Entities.Awp.CreateNew(awpInfo.awpId);
                    _context.Awps.Add(awp);
                    result.Added++;
                }
                else
                {
                    result.Updated++;
                }

                ConstructAwp(awpInfo, awp);
            }

            return result;
        }

        private void ConstructAwp(AwpInfo awpInfo, Entities.Awp awp)
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
