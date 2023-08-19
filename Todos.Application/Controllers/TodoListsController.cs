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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTodoList(Guid id)
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodoList(Guid id)
    {
        var todoListEntity = await _todoListRepository.GetById(id);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        await _todoListRepository.Delete(todoListEntity);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTodoList(Guid id, [FromBody] UpdateTodoListDTO updateTodoListDTO)
    {
        var todoListEntity = await _todoListRepository.GetById(id);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        todoListEntity.SetName(updateTodoListDTO.Name);

        await _todoListRepository.Update(todoListEntity);

        return Ok(todoListEntity.ToReadTodoListDTO());
    }

    [HttpPost("{todoListId:guid}/items")]
    public async Task<IActionResult> CreateTodo(Guid todoListId, [FromBody] CreateTodoDTO createTodoDTO)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var todoEntity = createTodoDTO.ToTodoEntity();
        todoListEntity.AddItem(todoEntity);
        await _todoListRepository.Update(todoListEntity);

        return CreatedAtAction(nameof(GetTodo), new { todoListId, todoId = todoEntity.Id }, todoEntity.ToReadTodoDTO());
    }

    [HttpGet("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> GetTodo(Guid todoListId, Guid todoId)
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

    [HttpPost("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> ToogleCompletedTodo(Guid todoListId, Guid todoId)
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

        todoEntity.ToogleCompleted();

        await _todoListRepository.Update(todoListEntity);

        return Ok(todoEntity.ToReadTodoDTO());
    }

    [HttpPut("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> UpdateTodo(Guid todoListId, Guid todoId, [FromBody] UpdateTodoDTO updateTodoDTO)
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

        todoEntity.SetContent(updateTodoDTO.Content);
        todoEntity.SetDueDate(updateTodoDTO.DueDate);

        await _todoListRepository.Update(todoListEntity);

        return Ok(todoEntity.ToReadTodoDTO());
    }

    [HttpDelete("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> DeleteTodo(Guid todoListId, Guid todoId)
    {
        var todoListEntity = await _todoListRepository.GetById(todoListId);
        if (todoListEntity == null)
        {
            return NotFound();
        }

        var amountRemoved = todoListEntity.RemoveItem(todoId);
        if (amountRemoved == 0)
        {
            return NotFound();
        }

        await _todoListRepository.Update(todoListEntity);

        return NoContent();
    }
}