namespace Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        protected BaseEntity(Guid id) => Id = id;

        protected BaseEntity()
        {
        }

        public Guid Id { get; set; }
    }
}
