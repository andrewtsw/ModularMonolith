using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.Finportal.Shared.Controllers.Extentions
{
    public static class IFormFileExtensions
    {
        public static async Task<byte[]> GetFileBytesAsync(this IFormFile file, CancellationToken cancellationToken)
        {
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms, cancellationToken);
            return ms.ToArray();
        }
    }
}
