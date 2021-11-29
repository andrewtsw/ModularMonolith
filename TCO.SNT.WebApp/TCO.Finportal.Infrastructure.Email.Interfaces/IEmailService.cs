using System.Threading.Tasks;

namespace TCO.Finportal.Infrastructure.Email.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string subject, string body, bool isBodyHtml, string[] to, StreamAttachment attachment = null);
    }
}
