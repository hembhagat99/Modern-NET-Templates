using ProjectName.Domain.Entities.Abstract;

namespace ProjectName.Domain.Repositories
{
    public interface IUserLinkedRepository<TKey, TEntity>
        where TEntity : BaseUserLinkedEntity<TKey>
    {
        public Task<TEntity> CreateForUserAsync(TEntity entity);

        public Task DeleteForUserAsync(TKey id, string userId);

        public Task<List<TEntity>> GetAllForUserAsync(string userId);

        public Task<TEntity> GetByIdForUserAsync(TKey id, string userId);

        public Task<TEntity> UpdateForUserAsync(TEntity entity);
    }
}
