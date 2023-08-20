using Todos.Api.Dtos;
using Todos.Core.DTOs;

namespace Todos.Api.Mappings;

public static class TodoListMappings
{
    public static ReadTodoListDTO ToReadTodoListDTO(this TodoListDTO todoListDTO) => new ReadTodoListDTO
    {
        Id = todoListDTO.Id,
        Owner = todoListDTO.Owner,
        Name = todoListDTO.Name,
        CreatedAt = todoListDTO.CreatedAt,
        Items = todoListDTO.Items.ToReadTodoDTO()
    };

    public static IEnumerable<ReadTodoListDTO> ToReadTodoListDTO(this IEnumerable<TodoListDTO> todoListDTOs) =>
        todoListDTOs.Select(t => t.ToReadTodoListDTO());

    public static TodoListDTO ToTodoListDTO(this CreateTodoListDTO createTodoListDTO) => new TodoListDTO
    {
        Name = createTodoListDTO.Name,
        Owner = createTodoListDTO.Owner
    };

    public static TodoListDTO ToTodoListDTO(this UpdateTodoListDTO updateTodoListDTO) => new TodoListDTO
    {
        Name = updateTodoListDTO.Name
    };
}