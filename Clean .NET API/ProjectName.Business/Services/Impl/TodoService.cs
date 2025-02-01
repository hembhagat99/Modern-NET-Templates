using ProjectName.Domain.Entities;
using ProjectName.Domain.Repositories;

namespace ProjectName.Business.Services.Impl
{
    internal class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<Todo>> GetAllTodosForUserAsync(string userId)
        {
            return await _todoRepository.GetAllForUserAsync(userId);
        }

        public async Task<Todo> GetTodoForUserByIdAsync(Guid todoId, string userId)
        {
            return await _todoRepository.GetByIdForUserAsync(todoId, userId);
        }

        public async Task<Todo> CreateTodoForUserAsync(Todo todo, string userId)
        {
            todo.UserId = userId;
            return await _todoRepository.CreateForUserAsync(todo);
        }

        public async Task<Todo> UpdateTodoForUserAsync(Todo todo, Guid todoId, string userId)
        {
            todo.Id = todoId;
            todo.UserId = userId;
            return await _todoRepository.UpdateForUserAsync(todo);
        }

        public async Task DeleteTodoForUserAsync(Guid todoId, string userId)
        {
            await _todoRepository.DeleteForUserAsync(todoId, userId);
        }
    }
}
