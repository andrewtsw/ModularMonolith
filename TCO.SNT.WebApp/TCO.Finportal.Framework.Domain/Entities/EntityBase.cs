namespace TCO.Finportal.Framework.Domain.Entities
{
    public abstract class EntityBase
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; protected set; }

        public bool IsNew() => Id <= 0;
    }
}
