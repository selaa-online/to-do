using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Interfaces;
using TodoApp.Core.Entities;

namespace TodoApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem todoItem)
        {
            var createdTodo = await _todoService.CreateTodoAsync(todoItem);
            return CreatedAtAction(nameof(GetById), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var existingTodo = await _todoService.GetTodoByIdAsync(id);
            if (existingTodo == null)
            {
                return NotFound();
            }

            await _todoService.UpdateTodoAsync(todoItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
    }
} 