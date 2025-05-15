using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Core.Entities;

namespace TodoApp.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem> GetByIdAsync(int id);
        Task<TodoItem> AddAsync(TodoItem todoItem);
        Task UpdateAsync(TodoItem todoItem);
        Task DeleteAsync(int id);
    }
} 