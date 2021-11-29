using Chevron.Identity.AspNet.Client;
using Microsoft.Extensions.Options;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;

namespace TCO.Finportal.Infrastructure.MsGraph.Sdk
{
    internal class MsGraphService : IMsGraphService
    {
        private static GraphServiceClient _graphServiceClient;
        private readonly AzureADOptions _azureADOptions;

        public MsGraphService(IOptions<AzureADOptions> azureADOptions)
        {
            // TODO: add custom options instead of AzureADOptions from Chevron package.
            _azureADOptions = azureADOptions.Value;
        }

        #region Private

        private static GraphServiceClient GetAuthenticatedGraphClient(AzureADOptions azureADOptions)
        {
            var authenticationProvider = CreateAuthorizationProvider(azureADOptions);
            _graphServiceClient = new GraphServiceClient(authenticationProvider);
            return _graphServiceClient;
        }

        private static IAuthenticationProvider CreateAuthorizationProvider(AzureADOptions azureADOptions)
        {
            var authority = $"https://login.microsoftonline.com/{azureADOptions.TenantId}/v2.0";

            //this specific scope means that application will default to what is defined in the application registration rather than using dynamic scopes
            var scopes = new string[] { "https://graph.microsoft.com/.default" };

            var cca = ConfidentialClientApplicationBuilder.Create(azureADOptions.ClientId)
                                              .WithAuthority(authority)
                                              .WithRedirectUri(azureADOptions.ApiAudience)
                                              .WithClientSecret(azureADOptions.ClientSecret)
                                              .Build();

            return new MsalAuthenticationProvider(cca, scopes);
        }

        #endregion

        public async Task<IReadOnlyList<MsGraphUser>> GetAdGroupMembersAsync(Guid groupId, CancellationToken cancellationToken)
        {
            var client = GetAuthenticatedGraphClient(_azureADOptions);
            var request = client.Groups[groupId.ToString()].Members.Request();
            var response = await request.Select("mail,id").GetAsync(cancellationToken);

            var members = response
                .Cast<User>()
                .Select(x => new MsGraphUser(x.Mail, Guid.Parse(x.Id)))
                .ToList();

            return members;
        }

        public async Task<IReadOnlyList<Guid>> GetUserParticipantAdGroups(IEnumerable<Guid> groupIds, Guid userId, CancellationToken cancellationToken)
        {
            var client = GetAuthenticatedGraphClient(_azureADOptions);

            var stringGroupIds = groupIds.Select(x => x.ToString()).ToList();
            var request = client.Users[userId.ToString()].CheckMemberGroups(stringGroupIds).Request();
            var response = await request.PostAsync(cancellationToken);

            var result = response
                .Select(q => Guid.Parse(q))
                .ToList();

            return result;
        }

        public async Task<IReadOnlyList<AdGroupDto>> SearchAdGroupsByPatternAsync(string seek, CancellationToken cancellationToken)
        {
            var client = GetAuthenticatedGraphClient(_azureADOptions);
            var request = client.Groups
                .Request()
                .Top(20)
                .Select("id,displayName");

            if (!string.IsNullOrEmpty(seek))
            {
                request = request.Filter($"startswith(displayName,'{Uri.EscapeDataString(seek)}')");
            }

            var response = await request.GetAsync(cancellationToken);

            return response.Select(x => new AdGroupDto { Id = x.Id, Name = x.DisplayName }).ToList();
        }

        public async Task<string> GetAdGroupNameByIdAsync(Guid groupId, CancellationToken cancellationToken)
        {
            var client = GetAuthenticatedGraphClient(_azureADOptions);
            var request = client.Groups[groupId.ToString()]
                .Request()
                .Select("id,displayName");

            var response = await request.GetAsync(cancellationToken);

            return response.DisplayName;
        }
    }
}
