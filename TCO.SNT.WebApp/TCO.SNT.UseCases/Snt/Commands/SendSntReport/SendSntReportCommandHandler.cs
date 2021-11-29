using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.Email.Interfaces;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Extentions;
using TCO.SNT.UseCases.Snt.Extensions;

namespace TCO.SNT.UseCases.Snt.Commands.SendSntReport
{
    internal class SendSntReportCommandHandler : AsyncRequestHandler<SendSntReportCommand>
    {
        private readonly IDbContext _context;
        private readonly IMsGraphService _msGraphService;
        private readonly IEmailService _emailService;
        private readonly ISntReportBuilder _reportBuilder;
        private readonly IDateTime _dateTime;
        private readonly SntReportOptions _reportOptions;
        private readonly CompanyOptions _companyOptions;

        public SendSntReportCommandHandler(IDbContext context,
            IMsGraphService msGraphUniversalService,
            IEmailService emailService,
            IDateTime dateTime,
            IOptions<SntReportOptions> reportOptions,
            ISntReportBuilder reportBuilder,
            IOptions<CompanyOptions> companyOptions)
        {
            _context = context;
            _msGraphService = msGraphUniversalService;
            _emailService = emailService;
            _reportBuilder = reportBuilder;
            _dateTime = dateTime;
            _reportOptions = reportOptions.Value;
            _companyOptions = companyOptions.Value;
        }

        protected override async Task Handle(SendSntReportCommand request, CancellationToken cancellationToken)
        {
            var adGroupMembers = await _msGraphService.GetAdGroupMembersAsync(_reportOptions.AdGroupId, cancellationToken);
            var emails = adGroupMembers
                .Select(q => q.Email)
                .ToArray();

            var sntList = await _context.Snts
                .AddAllSntIncludes()
                .ApplyFilter(request.Filter, _companyOptions)
                .OrderBy(q => q.Date)
                .ToListAsync(cancellationToken);

            var filterParams = new SntReportFilter(request.Filter.Category, request.Filter.Type, request.Filter.Status);

            // TODO: Get SNT report params for backgground job
            using var stream = _reportBuilder.BuildSntListReport(sntList, filterParams, request.BasePath);

            var steamAttachment = new StreamAttachment(stream, _reportOptions.FileName);

            var emailBody = string.Format(_reportOptions.Body, _dateTime.UtcNow.Date.ToStringCommonDateFormat());

            // TODO: Split email generation and email sending to different jobs.
            await _emailService.SendAsync(_reportOptions.Subject, emailBody, _reportOptions.IsBodyHtml, emails, steamAttachment);
        }
    }
}
