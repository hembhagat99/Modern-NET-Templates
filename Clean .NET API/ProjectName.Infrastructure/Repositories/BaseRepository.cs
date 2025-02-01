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
    internal abstract class BaseRepository<TKey, TEntity, TDataModel> : IRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
        where TDataModel : BaseDataModel<TKey>
    {
        private readonly ProjectNameDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbSet<TDataModel> _dbSet;

        public BaseRepository(ProjectNameDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = dbContext.Set<TDataModel>();
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var dataModel = _mapper.Map<TDataModel>(entity);
            _dbSet.Add(dataModel);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TEntity>(dataModel);
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var dataModel = await Query(trackChanges: true).FirstOrDefaultAsync(x => Object.Equals(x.Id, id));
            if (dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {id} not found");
            }

            _dbSet.Remove(dataModel);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            var dataModels = await Query().ToListAsync();
            return _mapper.Map<List<TEntity>>(dataModels);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var dataModel = await Query().FirstOrDefaultAsync(x => Equals(x.Id, id));
            if (dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {id} not found");
            }

            return _mapper.Map<TEntity>(dataModel);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var dataModel = await Query(trackChanges: true).FirstOrDefaultAsync(x => Equals(x.Id, entity.Id));
            if(dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {entity.Id} not found");
            }

            _mapper.Map(entity, dataModel);
            _dbSet.Update(dataModel);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TEntity>(dataModel);
        }

        protected async Task<List<TEntity>> GetAllByQueryAsync(Expression<Func<TDataModel, bool>> predicate)
        {
            var dataModels = await Query().Where(predicate).ToListAsync();
            return _mapper.Map<List<TEntity>>(dataModels);
        }

        protected async Task<TEntity> GetFirstByQueryAsync(Expression<Func<TDataModel, bool>> predicate)
        {
            var dataModel = await Query().FirstOrDefaultAsync(predicate);
            return _mapper.Map<TEntity>(dataModel);
        }

        private IQueryable<TDataModel> Query(bool trackChanges = false)
        {
            var queryable = trackChanges ? _dbSet : _dbSet.AsNoTracking();
            return Includes(queryable);
        }

        protected abstract IQueryable<TDataModel> Includes(IQueryable<TDataModel> queryable);
    }
}
