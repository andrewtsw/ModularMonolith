using TCO.Finportal.Framework.Domain.Exceptions;

namespace TCO.SNT.Entities.Exceptions
{
    public class ForbiddenException : DomainException
    {
        public ForbiddenException(string error) : base(error)
        {
        }
    }

}
