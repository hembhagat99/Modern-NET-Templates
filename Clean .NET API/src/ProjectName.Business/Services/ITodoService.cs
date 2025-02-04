using ProjectName.Domain.Entities;

namespace ProjectName.Business.Services
{
    public interface ITodoService
    {
        Task<List<Todo>> GetAllTodosForUserAsync(string userId);

        Task<Todo> GetTodoForUserByIdAsync(Guid todoId, string userId);

        Task<Todo> CreateTodoForUserAsync(Todo todo, string userId);

        Task<Todo> UpdateTodoForUserAsync(Todo todo, Guid todoId, string userId);

        Task DeleteTodoForUserAsync(Guid todoId, string userId);
    }
}
