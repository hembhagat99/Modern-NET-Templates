using SampleProj.Domain.Entities;

namespace SampleProj.Domain.Repositories
{
    public interface ITodoRepository : IRepository<Guid, Todo>
    {
    }
}
