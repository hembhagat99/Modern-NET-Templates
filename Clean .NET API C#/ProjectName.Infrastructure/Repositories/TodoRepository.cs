using AutoMapper;
using ProjectName.Domain.Entities;
using ProjectName.Domain.Repositories;
using ProjectName.Infrastructure.DataModels;
using ProjectName.Infrastructure.Dbcontext;

namespace ProjectName.Infrastructure.Repositories
{
    internal class TodoRepository : BaseRepository<Guid, Todo, TodoDataModel>, ITodoRepository
    {
        public TodoRepository(ProjectNameDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<TodoDataModel> Includes(IQueryable<TodoDataModel> queryable)
        {
            return queryable;
        }
    }
}
