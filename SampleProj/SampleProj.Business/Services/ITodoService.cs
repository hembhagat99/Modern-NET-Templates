using SampleProj.Domain.Entities;

namespace SampleProj.Business.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllAsync();

        Task<Todo> GetByIdAsync(Guid todoId);

        Task<Todo> CreateAsync(Todo todo);

        Task<Todo> UpdateAsync(Todo todo);

        Task DeleteAsync(Guid todoId);
    }
}
