namespace Framework.Domain
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; protected set; } // set to protected to adding seed data
        public bool IsDeleted { get; protected set; }
        public DateTime CreationDate { get; private set; }

        public BaseEntity()
        {
            CreationDate = DateTime.Now;
        }
    }
}