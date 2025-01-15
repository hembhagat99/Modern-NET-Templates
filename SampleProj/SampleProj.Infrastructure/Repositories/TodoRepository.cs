using AutoMapper;
using SampleProj.Domain.Entities;
using SampleProj.Domain.Repositories;
using SampleProj.Infrastructure.DataModels;
using SampleProj.Infrastructure.Dbcontext;

namespace SampleProj.Infrastructure.Repositories
{
    internal class TodoRepository : BaseRepository<Guid, Todo, TodoDataModel>, ITodoRepository
    {
        public TodoRepository(SampleProjDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }

        protected override IQueryable<TodoDataModel> Includes(IQueryable<TodoDataModel> queryable)
        {
            return queryable;
        }
    }
}
