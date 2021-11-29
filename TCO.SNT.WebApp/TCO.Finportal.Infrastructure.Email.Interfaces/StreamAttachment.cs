using System.IO;

namespace TCO.Finportal.Infrastructure.Email.Interfaces
{
    public class StreamAttachment
    {
        public StreamAttachment(Stream stream, string fileName)
        {
            Stream = stream;
            FileName = fileName;
        }

        public Stream Stream { get; }
        public string FileName { get; }
    }
}
