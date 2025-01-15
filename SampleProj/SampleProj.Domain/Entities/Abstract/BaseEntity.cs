namespace SampleProj.Domain.Entities.Abstract
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
