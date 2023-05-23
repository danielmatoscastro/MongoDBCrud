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
}