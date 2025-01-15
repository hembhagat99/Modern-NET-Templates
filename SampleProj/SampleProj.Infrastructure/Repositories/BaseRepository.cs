using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SampleProj.Domain.Entities.Abstract;
using SampleProj.Domain.Exceptions;
using SampleProj.Domain.Repositories;
using SampleProj.Infrastructure.DataModels.Abstract;
using SampleProj.Infrastructure.Dbcontext;

namespace SampleProj.Infrastructure.Repositories
{
    internal abstract class BaseRepository<TKey, TEntity, TDataModel> : IRepository<TKey, TEntity>
        where TEntity : BaseEntity<TKey>
        where TDataModel : BaseDataModel<TKey>
    {
        private readonly SampleProjDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly DbSet<TDataModel> _dbSet;

        public BaseRepository(SampleProjDbContext dbContext, IMapper mapper)
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

        public virtual async Task<List<TEntity>> GetAllByQueryAsync(Expression<Func<TDataModel, bool>> predicate)
        {
            var dataModels = await Query().Where(predicate).ToListAsync();
            return _mapper.Map<List<TEntity>>(dataModels);
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var dataModel = await Query().FirstOrDefaultAsync(x => Object.Equals(x.Id, id));
            return _mapper.Map<TEntity>(dataModel);
        }

        public virtual async Task<TEntity> GetFirstByQueryAsync(Expression<Func<TDataModel, bool>> predicate)
        {
            var dataModel = await Query().FirstOrDefaultAsync(predicate);
            return _mapper.Map<TEntity>(dataModel);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var dataModel = await Query(trackChanges: true).FirstOrDefaultAsync(x => Object.Equals(x.Id, entity.Id));
            if(dataModel == null)
            {
                throw new NotFoundException($"Entity {typeof(TEntity).Name} with id {entity.Id} not found");
            }

            _mapper.Map(entity, dataModel);
            _dbSet.Update(dataModel);

            await _dbContext.SaveChangesAsync();
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
