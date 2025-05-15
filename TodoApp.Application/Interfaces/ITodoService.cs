using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Application.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> GetTodoByIdAsync(int id);
        Task<TodoItem> CreateTodoAsync(TodoItem todoItem);
        Task UpdateTodoAsync(TodoItem todoItem);
        Task DeleteTodoAsync(int id);
    }
} 