using ProjectName.Domain.Entities.Abstract;

namespace ProjectName.Domain.Repositories
{
    public interface IRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
    {
        public Task<TEntity> CreateAsync(TEntity entity);

        public Task DeleteAsync(TKey id);

        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> GetByIdAsync(TKey id);

        public Task<TEntity> UpdateAsync(TEntity entity);
    }
}
