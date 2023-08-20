using Todos.Api.Dtos;
using Todos.Core.DTOs;

namespace Todos.Api.Mappings;

public static class TodoMappings
{
    public static List<ReadTodoDTO> ToReadTodoDTO(this IEnumerable<TodoDTO> todoDTOs) =>
        todoDTOs.Select(t => t.ToReadTodoDTO()).ToList();

    public static ReadTodoDTO ToReadTodoDTO(this TodoDTO todoDTO) =>
        new ReadTodoDTO
        {
            Id = todoDTO.Id,
            Completed = todoDTO.Completed,
            CompletedAt = todoDTO.CompletedAt,
            Content = todoDTO.Content,
            CreatedAt = todoDTO.CreatedAt,
            DueDate = todoDTO.DueDate,
        };

    public static TodoDTO ToTodoDTO(this CreateTodoDTO createTodoDTO) => new TodoDTO
    {
        Content = createTodoDTO.Content,
        DueDate = createTodoDTO.DueDate
    };

    public static TodoDTO ToTodoDTO(this UpdateTodoDTO updateTodoDTO) => new TodoDTO
    {
        Content = updateTodoDTO.Content,
        DueDate = updateTodoDTO.DueDate
    };
}