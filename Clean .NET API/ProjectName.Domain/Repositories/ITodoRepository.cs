using ProjectName.Domain.Entities;

namespace ProjectName.Domain.Repositories
{
    public interface ITodoRepository : IRepository<Guid, Todo>
    {
    }
}
