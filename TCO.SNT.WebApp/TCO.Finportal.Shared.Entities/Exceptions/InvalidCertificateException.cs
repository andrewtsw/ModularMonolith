using TCO.Finportal.Framework.Domain.Exceptions;

namespace TCO.Finportal.Shared.Entities.Exceptions
{
    public class InvalidCertificateException : DomainException
    {
        public InvalidCertificateException(string message) : base(message)
        {

        }
        public InvalidCertificateException() : base("Произошла ошибка во время чтение сертификата. Возможно был указан неверный пароль")
        {

        }
    }
}
