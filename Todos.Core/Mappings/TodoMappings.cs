using Todos.Core.Entities;

namespace Todos.Core.DTOs;

public static class TodoMappings
{
    public static IEnumerable<TodoDTO> ToTodoDTO(this IReadOnlyCollection<Todo> todos) =>
        todos.Select(todo => todo.ToTodoDTO());

    public static TodoDTO ToTodoDTO(this Todo todo) => new TodoDTO
    {
        Id = todo.Id,
        Content = todo.Content,
        Completed = todo.Completed,
        CompletedAt = todo.CompletedAt,
        CreatedAt = todo.CreatedAt,
        DueDate = todo.DueDate
    };

    public static Todo ToTodoEntity(this TodoDTO todoDTO) => new Todo(todoDTO.Content, todoDTO.DueDate);
}