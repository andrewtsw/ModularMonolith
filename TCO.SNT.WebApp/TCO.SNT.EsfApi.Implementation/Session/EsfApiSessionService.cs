using EsfApiSdk.Session;
using System;
using System.ServiceModel;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfIntegration.Shared.Security;
using TCO.SNT.EsfIntegration.Shared.Credential;
using TCO.SNT.EsfIntegration.Shared.Extensions;

namespace TCO.SNT.EsfApi.Implementation.Session
{
    internal class EsfApiSessionService : IEsfApiSessionService
    {
        private readonly EsfApiOptions _options;
        private readonly CompanyOptions _companyOptions;
        private readonly EsfAuthUserCredential _credential;

        public EsfApiSessionService(EsfApiOptions options,
            CompanyOptions companyOptions,
            EsfAuthUserCredential credential)
        {
            _options = options;
            _companyOptions = companyOptions;
            _credential = credential;
        }

        private Task<T> CreateClient<T>(Func<SessionServiceClient, Task<T>> func)
        {
            var client = new SessionServiceClient(
                SessionServiceClient.EndpointConfiguration.SessionServicePort,
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

        public async Task<sessionStatus> CloseSessionAsync(EsfApiSessionId sessionId)
        {
            var response = await CreateClient(client =>
                client.closeSessionAsync(new closeSession(new closeSessionRequest
                {
                    sessionId = sessionId.Value
                })));

            return response.closeSessionResponse.status;
        }

        public async Task<sessionStatus> CurrentSessionStatusAsync(EsfApiSessionId sessionId)
        {
            var response = await CreateClient(client =>
                client.currentSessionStatusAsync(new currentSessionStatus(new currentSessionStatusRequest
                {
                    sessionId = sessionId.Value
                })));

            return response.currentSessionStatusResponse.status;
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
