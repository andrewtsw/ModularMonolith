using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.Email.Interfaces;

namespace TCO.Finportal.Infrastructure.Email.Smtp
{
    internal class EmailService : IEmailService
    {
        private readonly EmailOptions _emailOptions;

        public EmailService(IOptions<EmailOptions> options)
        {
            _emailOptions = options.Value;
        }

        public async Task SendAsync(string subject, string body, bool isBodyHtml, string[] to, StreamAttachment attachment = null)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(_emailOptions.From)
            };
            foreach (var t in to)
            {
                mail.To.Add(t);
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = isBodyHtml;

            if (attachment != null)
            {
                mail.Attachments.Add(new Attachment(attachment.Stream, attachment.FileName));
            }

            using var smtpClient = new SmtpClient(_emailOptions.Server, _emailOptions.Port)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential(_emailOptions.Username, _emailOptions.Password),
            };
            await smtpClient.SendMailAsync(mail);
        }
    }
}
