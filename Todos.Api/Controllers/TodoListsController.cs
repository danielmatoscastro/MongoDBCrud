using Microsoft.AspNetCore.Mvc;
using Todos.Api.Dtos;
using Todos.Api.Mappings;
using Todos.Core.Repositories;
using Todos.Core.Services;

namespace Todos.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TodoListsController : ControllerBase
{
    private readonly TodoListService _todoListService;
    private readonly ITodoListRepository _todoListRepository;

    public TodoListsController(TodoListService todoListService, ITodoListRepository todoListRepository)
    {
        _todoListService = todoListService;
        _todoListRepository = todoListRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetTodoLists()
    {
        var todoListDtos = await _todoListService.GetAll();
        return Ok(todoListDtos.ToReadTodoListDTO());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetTodoList(Guid id)
    {
        var todoListDTO = await _todoListService.GetById(id);
        return Ok(todoListDTO.ToReadTodoListDTO());
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodoList([FromBody] CreateTodoListDTO createTodoListDTO)
    {
        var todoListDTO = createTodoListDTO.ToTodoListDTO();
        todoListDTO = await _todoListService.Create(todoListDTO);
        return CreatedAtAction(nameof(GetTodoList), new { todoListDTO.Id }, todoListDTO.ToReadTodoListDTO());
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodoList(Guid id)
    {
        await _todoListService.Delete(id);
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTodoList(Guid id, [FromBody] UpdateTodoListDTO updateTodoListDTO)
    {
        var todoListDTO = await _todoListService.Update(id, updateTodoListDTO.ToTodoListDTO());
        return Ok(todoListDTO.ToReadTodoListDTO());
    }

    [HttpPost("{todoListId:guid}/items")]
    public async Task<IActionResult> CreateTodo(Guid todoListId, [FromBody] CreateTodoDTO createTodoDTO)
    {
        var todoDTO = await _todoListService.CreateTodo(todoListId, createTodoDTO.ToTodoDTO());
        return CreatedAtAction(nameof(GetTodo), new { todoListId, todoId = todoDTO.Id }, todoDTO.ToReadTodoDTO());
    }

    [HttpGet("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> GetTodo(Guid todoListId, Guid todoId)
    {
        var todoDTO = await _todoListService.GetTodo(todoListId, todoId);
        return Ok(todoDTO.ToReadTodoDTO());
    }

    [HttpPost("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> ToogleCompletedTodo(Guid todoListId, Guid todoId)
    {
        var todoDTO = await _todoListService.ToogleCompletedTodo(todoListId, todoId);
        return Ok(todoDTO.ToReadTodoDTO());
    }

    [HttpPut("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> UpdateTodo(Guid todoListId, Guid todoId, [FromBody] UpdateTodoDTO updateTodoDTO)
    {
        var todoDTO = await _todoListService.UpdateTodo(todoListId, todoId, updateTodoDTO.ToTodoDTO());
        return Ok(todoDTO.ToReadTodoDTO());
    }

    [HttpDelete("{todoListId:guid}/items/{todoId:guid}")]
    public async Task<IActionResult> DeleteTodo(Guid todoListId, Guid todoId)
    {
        await _todoListService.DeleteTodo(todoListId, todoId);
        return NoContent();
    }
}