using AutoMapper;
using EsfApiSdk.Snt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Shared.Contract;
using TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Interfaces;
using TCO.SNT.Common.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.Snt;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.Snt.Shared;
using DomainError = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus
{
    internal class ChangeSntStatusCommandHandler : IRequestHandler<ChangeSntStatusCommand, SntSimpleDto>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _context;
        private readonly ErrorHelper _errorHelper;
        private readonly IBackgroungJobService _backgroungJobService;
        private readonly IEsfSntService _esfSntService;
        private readonly ISharedModuleContract _sharedModuleContract;
        private readonly IEsfApiSessionFactory _esfApiSessionFactory;
        private readonly UserAccessService _userAccessService;

        public ChangeSntStatusCommandHandler(
              IMapper mapper,
              IDbContext context,
              IEsfSntService esfSntService,
              IEsfApiSessionFactory esfApiSessionFactory,
              ISharedModuleContract sharedModuleContract, 
              ErrorHelper errorHelper,
              IBackgroungJobService backgroungJobService,
              UserAccessService userAccessService)
        {
            _mapper = mapper;
            _context = context;
            _esfSntService = esfSntService;
            _sharedModuleContract = sharedModuleContract;
            _esfApiSessionFactory = esfApiSessionFactory;
            _errorHelper = errorHelper;
            _backgroungJobService = backgroungJobService;
            _userAccessService = userAccessService;
        }

        public async Task<SntSimpleDto> Handle(ChangeSntStatusCommand request, CancellationToken cancellationToken)
        {
            var snt = await _context.LoadSntByIdAsync(request.ChangeSntStatusDto.SntId, cancellationToken);

            await _userAccessService.ThrowIfTaxpayerStoreForbidden(snt, cancellationToken);

            ThrowIfStatusChangeNotAllowed(snt, request.ActionType);

            var sntExterntalId = snt.ExternalId.Value;
            var sntAction = _mapper.Map<SntAction>(request);
            sntAction.sntId = sntExterntalId;
            sntAction.originalDocumentSignature = snt.DocumentInfo.Signature;

            var signatureInfo = await _sharedModuleContract.CreateSignatureAsync(sntAction, Entities.Snt.XmlMetadata, cancellationToken);

            SntChangeStatusResult response;
            await using (var session = await _esfApiSessionFactory.CreateSessionAsync(cancellationToken))
            {
                response = await _esfSntService.ChangeStatusAsync(session.SessionId, sntExterntalId, signatureInfo);
            }

            await ValidateChangeStatusResponseAsync(response, CancellationToken.None);

            _mapper.Map(response.sntSummary, snt.SntInfo);

            await _context.SaveChangesAsync(CancellationToken.None);

            _backgroungJobService.EnqueueImportBalances();

            return _mapper.Map<SntSimpleDto>(snt);
        }

        private async Task ValidateChangeStatusResponseAsync(SntChangeStatusResult response, CancellationToken cancellationToken)
        {
            if (!response.isChanged && !response.errors.IsNullOrEmpty())
            {

                var errorCodes = await _errorHelper.GetErrorDescriptionAsync(response.errors, cancellationToken);

                var errors = _mapper.Map<DomainError.Error[]>(errorCodes);

                throw new EsfOperationFailedException("Snt change status error", errors);
            }
        }

        private void ThrowIfStatusChangeNotAllowed(Entities.Snt snt, SntActionType sntActionType)
        {
            if (snt.IsFinished() ||
                (sntActionType == SntActionType.CONFIRM && !snt.IsAllowedToConfirm()) ||
                (sntActionType == SntActionType.REVOKE && !snt.IsAllowedToRevoke()) ||
                (sntActionType == SntActionType.DECLINE && !snt.IsAllowedToDecline()))
            {
                throw new ValidationException("Изменение статуса СНТ невозможно");
            }
        }
    }
}