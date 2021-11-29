using System;
using System.ServiceModel;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.EsfIntegration.Shared.Security;
using TCO.SNT.VStore.Implementation.Options;
using TCO.SNT.VStore.Interfaces;
using TCO.SNT.EsfIntegration.Shared.Credential;
using TCO.SNT.EsfIntegration.Shared.Extensions;
using VsSdk.VstoreSession;

namespace TCO.SNT.VStore.Implementation
{
    internal class VstoreSessionService : IVstoreSessionService
    {
        private readonly VStoreOptions _options;
        private readonly CompanyOptions _companyOptions;
        private readonly EsfAuthUserCredential _credential;

        public VstoreSessionService(VStoreOptions options,
            CompanyOptions companyOptions,
            EsfAuthUserCredential credential)
        {
            _options = options;
            _companyOptions = companyOptions;
            _credential = credential;
        }

        private Task<T> CreateClient<T>(Func<VstoreSessionServiceClient, Task<T>> func)
        {
            var client = new VstoreSessionServiceClient(
                VstoreSessionServiceClient.EndpointConfiguration.VstoreSessionServicePort,
                _options.GetSessionWebServiceAddress());

            client.ClientCredentials.EnsureCertificateValidationEnabled(_options.CertificateValidationEnabled);

            using var operationContextScope = new OperationContextScope(client.InnerChannel);

            OperationContext.Current.OutgoingMessageHeaders.Add(
                new SecurityHeader(_options.UserNameToken, _credential.Username, _credential.Password));

            return func(client);
        }

        #region Session methods

        public async Task<string> CreateSessionAsync()
        {
            var response = await CreateClient(client =>
                client.createSessionAsync(new createSession(new createSessionRequest
                {
                    tin = _companyOptions.Tin,
                    x509Certificate = _credential.AuthCertificate
                })));
            return response.createSessionResponse.sessionId;
        }

        public async Task<sessionStatus> CurrentSessionStatusAsync(VstoreSessionId sessionId)
        {
            var response = await CreateClient(client =>
                client.currentSessionStatusAsync(new currentSessionStatus(new currentSessionStatusRequest
                {
                    sessionId = sessionId.Value
                })));

            return response.currentSessionStatusResponse.status;
        }

        public async Task<sessionStatus> CloseSessionAsync(VstoreSessionId sessionId)
        {
            var response = await CreateClient(client =>
                client.closeSessionAsync(new closeSession(new closeSessionRequest 
                { 
                    sessionId = sessionId.Value
                })));

            return response.closeSessionResponse.status;
        }

        #endregion

        #region Service methods

        public async Task<sessionStatus> CloseSessionByCredentialsAsync()
        {
            var response = await CreateClient(client =>
                client.closeSessionByCredentialsAsync(new closeSessionByCredentials(new closeSessionByCredentialsRequest
                {
                    tin = _companyOptions.Tin,
                    x509Certificate = _credential.AuthCertificate
                })));

            return response.closeSessionResponse.status;
        }

        #endregion
    }
}
