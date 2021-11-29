using System.Collections.Generic;

namespace TCO.Finportal.Framework.Domain.Exceptions
{
    public class ValidationException : DomainException
    {
        public IEnumerable<KeyValuePair<string, string[]>> Errors { get; }

        public ValidationException(params string[] errors)
        {
            Errors = new List<KeyValuePair<string, string[]>>() { new KeyValuePair<string, string[]>("Common", errors) };
        }

        public ValidationException(IEnumerable<KeyValuePair<string, string[]>> errors)
        {
            Errors = errors;
        }
    }
}
