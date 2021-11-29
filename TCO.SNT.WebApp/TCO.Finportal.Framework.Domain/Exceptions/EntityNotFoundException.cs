
namespace TCO.Finportal.Framework.Domain.Exceptions
{
    public class EntityNotFoundException : DomainException
    {
        public EntityNotFoundException(string typeName) : base($"Entity {typeName} not found")
        {
        }
    }
}