using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectName.Domain.Entities.Abstract;
using ProjectName.Domain.Exceptions;
using ProjectName.Domain.Repositories;
using ProjectName.Infrastructure.DataModels.Abstract;
using ProjectName.Infrastructure.Dbcontext;

namespace ProjectName.Infrastructure.Repositories
{
    internal abstract class BaseUserLinkedRepository<TKey, TEntity, TDataModel> : IUserLinkedRepository<TKey, TEntity>
        where TEntity : BaseUserLinkedEntity<TKey>
        where TDataModel : BaseUserLinkedDataModel<TKey>
    {
        private readonly ProjectNameDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbSet<TDataModel> _dbSet;

        public BaseUserLinkedRepository(ProjectNameDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = dbContext.Set<TDataModel>();
        }

        public virtual async Task<TEntity> CreateForUserAsync(TEntity entity)
        {
            var dataModel = _mapper.Map<TDataModel>(entity);
            _dbSet.Add(dataModel);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TEntity>(dataModel);
        }

        public virtual async Task DeleteForUserAsync(TKey id, string userId)
        {
            var dataModel = await QueryForUser(userId, trackChanges: true)
                .FirstOrDefaultAsync(x => Equals(x.Id, id));

            if (dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {id} not found for user {userId}");
            }

            _dbSet.Remove(dataModel);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllForUserAsync(string userId)
        {
            var dataModels = await QueryForUser(userId).ToListAsync();
            return _mapper.Map<List<TEntity>>(dataModels);
        }

        public virtual async Task<TEntity> GetByIdForUserAsync(TKey id, string userId)
        {
            var dataModel = await QueryForUser(userId).FirstOrDefaultAsync(x => Equals(x.Id, id));
            if (dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {id} not found for user {userId}");
            }

            return _mapper.Map<TEntity>(dataModel);
        }

        public virtual async Task<TEntity> UpdateForUserAsync(TEntity entity)
        {
            var dataModel = await QueryForUser(entity.UserId, trackChanges: true).FirstOrDefaultAsync(x => Equals(x.Id, entity.Id));
            if (dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {entity.Id} not found for user {entity.UserId}");
            }

            _mapper.Map(entity, dataModel);
            _dbSet.Update(dataModel);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TEntity>(dataModel);
        }
        protected async Task<List<TEntity>> GetAllForUserByQueryAsync(string userId, Expression<Func<TDataModel, bool>> predicate)
        {
            var dataModels = await QueryForUser(userId).Where(predicate).ToListAsync();
            return _mapper.Map<List<TEntity>>(dataModels);
        }

        protected async Task<TEntity> GetFirstForUserByQueryAsync(string userId, Expression<Func<TDataModel, bool>> predicate)
        {
            var dataModel = await QueryForUser(userId).FirstOrDefaultAsync(predicate);
            return _mapper.Map<TEntity>(dataModel);
        }

        private IQueryable<TDataModel> QueryForUser(string userId, bool trackChanges = false)
        {
            var queryForUser = _dbSet.Where(x => x.UserId == userId);
            var queryable = trackChanges ? queryForUser : queryForUser.AsNoTracking();

            return Includes(queryable);
        }

        protected abstract IQueryable<TDataModel> Includes(IQueryable<TDataModel> queryable);
    }
}
