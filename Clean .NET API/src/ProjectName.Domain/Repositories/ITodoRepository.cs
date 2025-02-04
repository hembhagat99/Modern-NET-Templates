using ProjectName.Domain.Entities;

namespace ProjectName.Domain.Repositories
{
    public interface ITodoRepository : IUserLinkedRepository<Guid, Todo>
    {
    }
}
