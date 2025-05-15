using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Application.Interfaces;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;

namespace TodoApp.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return await _todoRepository.GetAllAsync();
        }

        public async Task<TodoItem> GetTodoByIdAsync(int id)
        {
            return await _todoRepository.GetByIdAsync(id);
        }

        public async Task<TodoItem> CreateTodoAsync(TodoItem todoItem)
        {
            return await _todoRepository.AddAsync(todoItem);
        }

        public async Task UpdateTodoAsync(TodoItem todoItem)
        {
            await _todoRepository.UpdateAsync(todoItem);
        }

        public async Task DeleteTodoAsync(int id)
        {
            await _todoRepository.DeleteAsync(id);
        }
    }
} 