using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Shared.Contract;
using TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Interfaces;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.UseCases.ApplicationServices;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.Vstore.Interfaces.UForm;
using TCO.SNT.VStore.Interfaces;
using DomainError = TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.UForms.Commands.SendUForm
{
    internal class SendUFormCommandHandler : AsyncRequestHandler<SendUFormCommand>
    {
        private readonly IDbContext _context;
        private readonly IVstoreUFormService _vstoreUFormService;
        private readonly IVstoreSessionFactory _vstoreSessionFactory;
        private readonly ISharedModuleContract _sharedModuleContract;
        private readonly UserAccessService _userAccessService;
        private readonly IMapper _mapper;
        private readonly IBackgroungJobService _backgroungJobService;

        public SendUFormCommandHandler(IDbContext context,
            IVstoreUFormService vstoreUFormService,
            IVstoreSessionFactory vstoreSessionFactory,
            ISharedModuleContract sharedModuleContract,
            UserAccessService userAccessService,
            IMapper mapper,
            IBackgroungJobService backgroungJobService)
        {
            _context = context;
            _vstoreUFormService = vstoreUFormService;
            _vstoreSessionFactory = vstoreSessionFactory;
            _sharedModuleContract = sharedModuleContract;
            _userAccessService = userAccessService;
            _mapper = mapper;
            _backgroungJobService = backgroungJobService;
        }

        protected override async Task Handle(SendUFormCommand request, CancellationToken cancellationToken)
        {
            var form = await _context.LoadUFormByIdAsync(request.FormId, cancellationToken);

            _userAccessService.ThrowIfUserNotAllowedToSendUform(form.Type);
            await _userAccessService.ThrowIfTaxpayerStoreForbidden(form, cancellationToken);

            if (!form.CanBeSentToEsf())
            {
                throw new ValidationException("Invalid form status. You are able to send only forms in the DRAFT status.");
            }

            // Comment field is required in ESF API but not required on original ESP Portal,
            // this is workaround to allow users of our UI not to fill Comment
            if (string.IsNullOrEmpty(form.Comment))
            {
                form.Comment = " ";
            }

            await using (var session = await _vstoreSessionFactory.CreateSessionAsync(cancellationToken))
            {
                await UploadFormAsync(form, session, cancellationToken);
                await UpdateFormAsync(form, session);
            }

            _backgroungJobService.EnqueueImportBalances();
        }

        private async Task UploadFormAsync(Entities.UForm form, IVstoreSession session, CancellationToken cancellationToken)
        {
            var formModel = _mapper.Map<UForm>(form);

            var signatureInfo = await _sharedModuleContract.CreateSignatureAsync(formModel, Entities.UForm.XmlMetaData, cancellationToken);
            var uploadResponse = await _vstoreUFormService.UploadUFormAsync(session.SessionId, signatureInfo);

            var externalId = GetExternalIdFromValidatedResponse(uploadResponse.uploadUFormResponse);
            form.SetExternalId(externalId);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        private async Task UpdateFormAsync(Entities.UForm form, IVstoreSession session)
        {
            var formInfo = await _vstoreUFormService.GetUFormAsync(session.SessionId, form.ExternalId.Value);
            _mapper.Map(formInfo, form.UFormInfo);
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        private long GetExternalIdFromValidatedResponse(VsSdk.UForm.UploadUFormResponse response)
        {
            if (response.declinedList.Any())
            {
                var errors = _mapper.Map<DomainError.Error[]>(response.declinedList.Single().errorList);
                throw new EsfOperationFailedException("UForm upload error: Form was declined", errors);
            }

            var result = response.acceptedList.Single();
            if (!result.idSpecified || result.id <= 0)
            {
                throw new EsfOperationFailedException("UForm upload error: id must be positive");
            }

            return result.id;
        }
    }
}