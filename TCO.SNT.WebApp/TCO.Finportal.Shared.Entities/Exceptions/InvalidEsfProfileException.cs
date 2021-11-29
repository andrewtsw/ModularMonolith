using TCO.Finportal.Framework.Domain.Exceptions;

namespace TCO.Finportal.Shared.Entities.Exceptions
{
    public class InvalidEsfProfileException : DomainException
    {
        public InvalidEsfProfileException() : base("Не заполнен профиль пользователя.")
        {
        }
    }
}
