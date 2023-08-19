using Microsoft.AspNetCore.Mvc;
using Todos.Application.Dtos;
using Todos.Application.Mappings;
using Todos.Domain.Repositories;

namespace Todos.Application.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TodoListsController : ControllerBase
{
    private readonly ITodoListRepository _todoListRepository;

    public TodoListsController(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodoLists()
    {
        var todoListEntities = await _todoListRepository.GetAll();
        return Ok(todoListEntities.ToReadTodoListDTO());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoList(string id)
    {
        var todoListEntity = await _todoListRepository.GetById(id);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        return Ok(todoListEntity.ToReadTodoListDTO());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoList([FromBody] CreateTodoListDTO createTodoListDTO)
    {
        var todoListEntity = createTodoListDTO.ToTodoListEntity();
        todoListEntity = await _todoListRepository.Create(todoListEntity);
        return CreatedAtAction(nameof(GetTodoList), new { id = todoListEntity.Id }, todoListEntity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoList(string id)
    {
        var todoListEntity = await _todoListRepository.GetById(id);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        await _todoListRepository.Delete(todoListEntity);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodoList(string id, [FromBody] UpdateTodoListDTO updateTodoListDTO)
    {
        var todoListEntity = await _todoListRepository.GetById(id);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        todoListEntity.Name = updateTodoListDTO.Name;

        await _todoListRepository.Update(todoListEntity);

        return Ok(todoListEntity.ToReadTodoListDTO());
    }

    [HttpPost("{todoListId}/items")]
    public async Task<IActionResult> CreateTodo(string todoListId, [FromBody] CreateTodoDTO createTodoDTO)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var todoEntity = createTodoDTO.ToTodoEntity();
        await _todoListRepository.CreateItem(todoListId, todoEntity);

        return CreatedAtAction(nameof(GetTodo), new { todoListId, todoId = todoEntity.Id }, todoEntity.ToReadTodoDTO());
    }

    [HttpGet("{todoListId}/items/{todoId}")]
    public async Task<IActionResult> GetTodo(string todoListId, string todoId)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var todoEntity = todoListEntity.Items.FirstOrDefault(item => item.Id == todoId);
        if (todoEntity == null)
        {
            return NotFound();
        }

        return Ok(todoEntity.ToReadTodoDTO());
    }

    [HttpPost("{todoListId}/items/{todoId}")]
    public async Task<IActionResult> ToogleCompletedTodo(string todoListId, string todoId)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var todoEntity = todoListEntity.Items.FirstOrDefault(item => item.Id == todoId);
        if (todoEntity == null)
        {
            return NotFound();
        }

        todoEntity.CompletedAt = todoEntity.Completed ? null : DateTime.UtcNow;
        todoEntity.Completed = !todoEntity.Completed;

        await _todoListRepository.Update(todoListEntity);

        return Ok(todoEntity.ToReadTodoDTO());
    }

    [HttpPut("{todoListId}/items/{todoId}")]
    public async Task<IActionResult> UpdateTodo(string todoListId, string todoId, [FromBody] UpdateTodoDTO updateTodoDTO)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var todoEntity = todoListEntity.Items.FirstOrDefault(item => item.Id == todoId);
        if (todoEntity == null)
        {
            return NotFound();
        }

        todoEntity.Content = updateTodoDTO.Content;
        todoEntity.DueDate = updateTodoDTO.DueDate;

        await _todoListRepository.Update(todoListEntity);

        return Ok(todoEntity.ToReadTodoDTO());
    }

    [HttpDelete("{todoListId}/items/{todoId}")]
    public async Task<IActionResult> DeleteTodo(string todoListId, string todoId)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var amountRemoved = todoListEntity.Items.RemoveAll(item => item.Id == todoId);
        if (amountRemoved == 0)
        {
            return NotFound();
        }

        await _todoListRepository.Update(todoListEntity);

        return NoContent();
    }
}