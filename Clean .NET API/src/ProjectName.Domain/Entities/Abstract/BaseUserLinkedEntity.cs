namespace ProjectName.Domain.Entities.Abstract
{
    public abstract class BaseUserLinkedEntity<TKey> : BaseEntity<TKey>
    {
        public string UserId { get; set; }
    }
}
