using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.Resources;
using TCO.SNT.Entities;
using TCO.Finportal.Infrastructure.Email.Interfaces;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;

namespace TCO.SNT.UseCases.Snt.Commands.SendSntNotification
{
    internal class SendSntNotificationCommandHandler : AsyncRequestHandler<SendSntNotificationCommand>
    {
        private readonly IMsGraphService _msGraphService;
        private readonly IEmailService _emailService;
        private readonly ISntReportBuilder _reportBuilder;
        private readonly SntNotificationOptions _notificationOptions;
        private readonly CompanyOptions _companyOptions;
        private readonly IDbContext _context;
        private readonly IDateTime _dateTime;

        public SendSntNotificationCommandHandler(IMsGraphService msGraphUniversalService,
            IEmailService emailService,
            IOptions<SntNotificationOptions> notificationOptions,
            IOptions<CompanyOptions> companyOptions,
            ISntReportBuilder reportBuilder,
            IDbContext context,
            IDateTime dateTime)
        {
            _msGraphService = msGraphUniversalService;
            _emailService = emailService;
            _reportBuilder = reportBuilder;
            _notificationOptions = notificationOptions.Value;
            _companyOptions = companyOptions.Value;
            _context = context;
            _dateTime = dateTime;
        }

        protected override async Task Handle(SendSntNotificationCommand request, CancellationToken cancellationToken)
        {
            var adGroupMembers = await _msGraphService.GetAdGroupMembersAsync(_notificationOptions.AdGroupId, cancellationToken);

            var recipientTaxpareStores = await GetUserAllowedTaxpareStores(adGroupMembers, cancellationToken);

            var sntNotifications = await GetNotificationByRecipient(recipientTaxpareStores, cancellationToken);

            foreach (var notification in sntNotifications)
            {
                // TODO: Split email generation and email sending to different jobs.
                await _emailService.SendAsync(SntNotificationResource.NotificationEmailSubject, notification.Item1, true, new string[] { notification.Item2 });
            }
        }

        private async Task<Dictionary<string, IEnumerable<int>>> GetUserAllowedTaxpareStores(IEnumerable<MsGraphUser> users, CancellationToken cancellationToken)
        {
            var result = new Dictionary<string, IEnumerable<int>>();

            if (!users.Any())
            {
                return result;
            }

            var taxpayersAdGroups = await _context.GroupTaxpayerStores
                                        .Select(q => q.GroupId)
                                        .Distinct()
                                        .ToArrayAsync(cancellationToken);

            foreach (var user in users)
            {
                var userAdGroups = await _msGraphService.GetUserParticipantAdGroups(taxpayersAdGroups, user.Id, cancellationToken);

                if (!userAdGroups.Any())
                {
                    continue;
                }

                var taxpareStoreIds = await _context.GroupTaxpayerStores
                    .Where(q => userAdGroups.Contains(q.GroupId))
                    .Select(q => q.TaxpayerStoreId)
                    .Distinct()
                    .ToListAsync(cancellationToken);

                if (!taxpareStoreIds.Any())
                {
                    continue;
                }

                result.Add(user.Email, taxpareStoreIds);
            }

            return result;
        }

        private async Task<IReadOnlyList<(string, string)>> GetNotificationByRecipient(Dictionary<string, IEnumerable<int>> recipientsTaxpareStores, CancellationToken cancellationToken)
        {
            var allTaxpareStoreIds = recipientsTaxpareStores.SelectMany(q => q.Value);

            var sntsForActionRequired = await _context.Snts
                      .AddAllSntIncludes()
                      .Where(q =>
                          q.Date.HasValue &&
                         (q.SntInfo.Status == SntStatus.NOT_VIEWED || q.SntInfo.Status == SntStatus.DELIVERED) &&
                          q.Customer.Tin == _companyOptions.Tin &&
                          q.Customer.TaxpayerStoreId.HasValue &&
                          allTaxpareStoreIds.Contains(q.Customer.TaxpayerStoreId.Value))
                      .OrderBy(q => q.Date)
                      .ToListAsync(cancellationToken);

            var result = new List<(string, string)>();

            foreach (var recipientTaxpareStores in recipientsTaxpareStores)
            {
                var taxpayerStores = recipientTaxpareStores.Value;

                var recipientSnts = sntsForActionRequired
                                     .Where(q =>
                                                  taxpayerStores.Contains(q.Customer.TaxpayerStoreId.Value) &&
                                                 (q.IsNearDeadline(_dateTime.UtcNow, _notificationOptions.DaysUntilDeadline) ||
                                                  q.IsExceedDeadline(_dateTime.UtcNow)))
                                     .ToList();

                var notification = _reportBuilder.BuildSntNotification(recipientSnts);
                var email = recipientTaxpareStores.Key;

                result.Add((notification, email));
            }

            return result;
        }
    }
}