using Todos.Application.Dtos;
using Todos.Domain.Entities;

namespace Todos.Application.Mappings;

public static class TodoMappings
{
    public static List<ReadTodoDTO> ToReadTodoDTO(this List<Todo> todos) =>
        todos.Select(t => t.ToReadTodoDTO()).ToList();

    public static ReadTodoDTO ToReadTodoDTO(this Todo todo) => new ReadTodoDTO();
}