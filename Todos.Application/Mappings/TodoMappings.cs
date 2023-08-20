using Todos.Application.Dtos;
using Todos.Core.Entities;

namespace Todos.Application.Mappings;

public static class TodoMappings
{
    public static List<ReadTodoDTO> ToReadTodoDTO(this IReadOnlyCollection<Todo> todos) =>
        todos.Select(t => t.ToReadTodoDTO()).ToList();

    public static ReadTodoDTO ToReadTodoDTO(this Todo todo) =>
        new ReadTodoDTO
        {
            Id = todo.Id,
            Completed = todo.Completed,
            CompletedAt = todo.CompletedAt,
            Content = todo.Content,
            CreatedAt = todo.CreatedAt,
            DueDate = todo.DueDate,
        };

    public static Todo ToTodoEntity(this CreateTodoDTO createTodoDTO) =>
        new Todo(createTodoDTO.Content, createTodoDTO.DueDate);
}