using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Core.Entities;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetByIdAsync(int id)
        {
            return await _context.TodoItems.FindAsync(id);
        }

        public async Task<TodoItem> AddAsync(TodoItem todoItem)
        {
            todoItem.CreatedAt = DateTime.UtcNow;
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task UpdateAsync(TodoItem todoItem)
        {
            if (todoItem.IsCompleted && !todoItem.CompletedAt.HasValue)
            {
                todoItem.CompletedAt = DateTime.UtcNow;
            }
            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem != null)
            {
                _context.TodoItems.Remove(todoItem);
                await _context.SaveChangesAsync();
            }
        }
    }
} 