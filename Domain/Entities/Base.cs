

namespace Domain.Entities
{
    public abstract class Base
    {
        public Guid Id { get; private set; }= Guid.NewGuid();

        internal void SetId(Guid id)
        {
            this.Id = id;
        }
    }
}
