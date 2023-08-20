using Todos.Core.DTOs;
using Todos.Core.Entities;

namespace Todos.Core.Mappings;

public static class TodoListMappings
{
    public static IEnumerable<TodoListDTO> ToTodoListDTO(this IEnumerable<TodoList> todoLists) =>
        todoLists.Select(todoList => todoList.ToTodoListDTO());

    public static TodoListDTO ToTodoListDTO(this TodoList todoList) => new TodoListDTO
    {
        Id = todoList.Id,
        Name = todoList.Name,
        Owner = todoList.Owner,
        CreatedAt = todoList.CreatedAt,
        Items = todoList.Items.ToTodoDTO()
    };

    public static TodoList ToTodoListEntity(this TodoListDTO todoListDTO) => new TodoList(todoListDTO.Owner, todoListDTO.Name);
}