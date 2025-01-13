using ProjectName.Domain.Entities;
using ProjectName.Domain.Repositories;

namespace ProjectName.Business.Services.Impl
{
    internal class TodoService(ITodoRepository todoRepository) : ITodoService
    {
        public async Task<List<Todo>> GetAllAsync()
        {
            return await todoRepository.GetAllAsync();
        }

        public async Task<Todo> GetByIdAsync(Guid todoId)
        {
            return await todoRepository.GetByIdAsync(todoId);
        }

        public async Task<Todo> CreateAsync(Todo todo)
        {
            return await todoRepository.CreateAsync(todo);
        }

        public async Task<Todo> UpdateAsync(Todo todo)
        {
            return await todoRepository.UpdateAsync(todo);
        }

        public async Task DeleteAsync(Guid todoId)
        {
            await todoRepository.DeleteAsync(todoId);
        }
    }
}
