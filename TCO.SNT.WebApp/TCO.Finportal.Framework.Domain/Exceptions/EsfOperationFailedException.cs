using System.Collections.Generic;
using System.Linq;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.Finportal.Framework.Domain.Exceptions
{
    public class EsfOperationFailedException : DomainException
    {
        public IDictionary<string, string[]> Errors { get; }

        public EsfOperationFailedException(string message, Error[] errors = null) 
            : base (message)
        {
            if (errors != null)
            {
                Errors = ExtractErrors(errors);
            }
            else
            {
                Errors = new Dictionary<string, string[]>();
            }
        }

        private IDictionary<string, string[]> ExtractErrors(Error[] errors)
        {
            // Group by property because it is a key for dictionary
            return errors
                .GroupBy(error => error.Property ?? string.Empty)
                .Select(group =>
                {
                    var errors = group
                        .Select(e => e.Text)
                        .ToArray();
                    return (Property: group.Key, Errors: errors);
                })
                .ToDictionary(x => x.Property, x => x.Errors);
        }
    }
}
