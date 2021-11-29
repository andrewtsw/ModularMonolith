using System.IO;

namespace TCO.SNT.UseCases.Shared
{
    public class FileStreamBaseDto
    {
        public Stream FileStream { get; set; }

        public string FileName { get; set; }
    }
}