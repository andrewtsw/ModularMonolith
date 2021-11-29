using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.Finportal.Shared.Contract;
using TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Interfaces;
using TCO.SNT.Common.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.Snt;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.Snt.Commands.Import.Validators;
using DomainError = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.Snt.Commands.SendSnt
{
    internal class SendSntCommandHandler : AsyncRequestHandler<SendSntCommand>
    {
        private readonly IDbContext _context;
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly IEsfSntService _esfSntService;
        private readonly ISharedModuleContract _sharedModuleContract;
        private readonly IMapper _mapper;
        private readonly IDateTime _dateTime;
        private readonly IBackgroungJobService _backgroungJobService;

        public SendSntCommandHandler(IDbContext context,
            IEsfSntService esfSntService,
            IEsfApiSessionFactory esfApiSessionFactory,
            ISharedModuleContract sharedModuleContract,
            IMapper mapper,
            IDateTime dateTime,
            IBackgroungJobService backgroungJobService)
        {
            _context = context;
            _esfSntService = esfSntService;
            _esfApiSessionFactory = esfApiSessionFactory;
            _sharedModuleContract = sharedModuleContract;
            _mapper = mapper;
            _dateTime = dateTime;
            _backgroungJobService = backgroungJobService;
        }

        protected override async Task Handle(SendSntCommand request, CancellationToken cancellationToken)
        {
            var snt = await _context.LoadSntByIdAsync(request.Dto.SntId, cancellationToken);

            ValidateSntStatus(snt);

            await UpdateSntDatesAsync(snt, request.Dto.LocalTimezoneOffsetMinutes, cancellationToken);

            await using (var session = await _esfApiSessionFactory.CreateSessionAsync( cancellationToken))
            {
                await UploadSntAsync(snt, session, cancellationToken);
                await UpdateSntInfoAsync(snt, session);
                if (!string.IsNullOrEmpty(snt.RelatedRegistrationNumber))
                {
                    var relatedSnt = await _context.LoadSntInfoByRegistrationNumberAsync(snt.RelatedRegistrationNumber, CancellationToken.None);
                    await UpdateSntInfoAsync(relatedSnt, session);
                }
            }

            _backgroungJobService.EnqueueImportBalances();
        }

        private async Task UpdateSntDatesAsync(Entities.Snt snt, int offsetMinutes, CancellationToken cancellationToken)
        {
            snt.UpdateUtcDates(_dateTime.UtcNow);
            snt.Date = _dateTime.UtcNow.SetDateWithOffset(offsetMinutes);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private void ValidateSntStatus(Entities.Snt snt)
        {
            if (snt.SntInfo.Status != Entities.SntStatus.DRAFT)
            {
                throw new ValidationException("Отправка в ЭСФ доступна только для СНТ в статусе 'Черновик'");
            }
        }

        private async Task UploadSntAsync(Entities.Snt snt, IEsfApiSession session, CancellationToken cancellationToken)
        {
            var sntModel = _mapper.Map<SntV1>(snt);

            var signatureInfo = await _sharedModuleContract.CreateSignatureAsync(sntModel, Entities.Snt.XmlMetadata, cancellationToken);

            var uploadResponse = await _esfSntService.UploadSntAsync(session.SessionId, signatureInfo);

            var externalId = GetExternalIdFromValidatedResponse(uploadResponse);
            snt.SetExternalId(externalId);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        private async Task UpdateSntInfoAsync(Entities.Snt snt, IEsfApiSession session)
        {
            var sntInfo = await _esfSntService.GetSntAsync(session.SessionId, snt.ExternalId.Value);

            new SntInfoValidator().EnsureIsValid(sntInfo);

            MapSntInfoToSnt(sntInfo, snt);

            await _context.SaveChangesAsync(CancellationToken.None);
        }

        private void MapSntInfoToSnt(EsfApiSdk.Snt.SntInfo sntInfo, Entities.Snt snt)
        {
            _mapper.Map(sntInfo, snt.SntInfo);

            snt.DocumentInfo = new Entities.SntDocumentInfo();
            _mapper.Map(sntInfo.documentInfo, snt.DocumentInfo);

            if (sntInfo.acceptanceGoodsInfo != null)
            {
                snt.CreateAcceptanceGoodsIfNotExists();
                _mapper.Map(sntInfo.acceptanceGoodsInfo, snt.AcceptanceGoodsInfo);
            }

            if (sntInfo.ogdMarksInfo != null)
            {
                snt.CreateOgdMarksInfoIfNotExists();
                _mapper.Map(sntInfo.ogdMarksInfo, snt.OgdMarksInfo);
            }
        }

        private long GetExternalIdFromValidatedResponse(EsfApiSdk.Snt.UploadSntResponse response)
        {
            if (response.declinedList.Any())
            {
                var errors = _mapper.Map<DomainError.Error[]>(response.declinedList.Single().errorList);
                throw new EsfOperationFailedException("SNT upload error: SNT was declined", errors);
            }

            var result = response.acceptedList.Single();
            if (!result.sntIdSpecified || result.sntId <= 0)
            {
                throw new EsfOperationFailedException("SNT upload error: id must be positive");
            }

            return result.sntId;
        }
    }
}
