using AutoMapper;
using EsfApiSdk.Snt;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.Snt;
using TCO.SNT.UseCases.Extentions;
using DomainError = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntFull
{
    internal class GetSntFullQueryHandler : IRequestHandler<GetSntFullQuery, SntFullDto>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfSntService _esfSntService;
        private readonly CompanyOptions _companyOptions;

        public GetSntFullQueryHandler(
            IDbContext context,
            IMapper mapper,
            IEsfSntService esfSntService,
            IEsfApiSessionFactory esfApiSessionFactory,
            IOptions<CompanyOptions> companyOptions
            )
        {
            _context = context;
            _mapper = mapper;
            _esfApiSessionFactory = esfApiSessionFactory;
            _esfSntService = esfSntService;
            _companyOptions = companyOptions.Value;
        }

        public async Task<SntFullDto> Handle(GetSntFullQuery request, CancellationToken cancellationToken)
        {
            var snt = await _context.LoadSntByIdAsync(request.SntId, cancellationToken);

            var sntFull = _mapper.Map<SntFullDto>(snt);

            await MarkSntAsDeliveredIfNotViewed(snt, cancellationToken);

            return sntFull;
        }

        private async Task MarkSntAsDeliveredIfNotViewed(Entities.Snt snt, CancellationToken cancellationToken)
        {
            // To mark SNT as Delivered on ESF call GetSntViewAsync for NOT_VIEWED
            if (snt.IsInbound(_companyOptions) && snt.SntInfo.Status == Entities.SntStatus.NOT_VIEWED)
            {
                SntSummary sntSummary;
                await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
                {
                    // Check if SNT status is NOT_VIEWED on ESF portal
                    // because DELIVERED status not comes in SntImport updates and we should handle it here
                    sntSummary = await _esfSntService.GetSntStatusAsync(session.SessionId, snt.ExternalId.Value);
                    if (sntSummary.status == SntStatus.NOT_VIEWED)
                    {
                        var response = await _esfSntService.GetSntViewAsync(session.SessionId, snt.ExternalId.Value);
                        ValidateChangeStatusResponse(response);

                        sntSummary = response.sntSummary;
                    }
                }

                _mapper.Map(sntSummary, snt.SntInfo);

                await _context.SaveChangesAsync(CancellationToken.None);
            }
        }

        private void ValidateChangeStatusResponse(SntChangeStatusResult response)
        {
            if (!response.isChanged && !response.errors.IsNullOrEmpty())
            {
                var errors = _mapper.Map<DomainError.Error[]>(response.errors);
                throw new EsfOperationFailedException("Snt change status error", errors);
            }
        }
    }
}
