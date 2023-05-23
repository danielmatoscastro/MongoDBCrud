using Todos.Application.Dtos;
using Todos.Domain.Entities;

namespace Todos.Application.Mappings;

public static class TodoListMappings
{
    public static ReadTodoListDTO ToReadTodoListDTO(this TodoList todoList) => new ReadTodoListDTO
    {
        Id = todoList.Id,
        Owner = todoList.Owner,
        Name = todoList.Name,
        CreatedAt = todoList.CreatedAt,
        Items = todoList.Items.ToReadTodoDTO()
    };

    public static TodoList ToTodoListEntity(this CreateTodoListDTO createTodoListDTO) =>
        new TodoList(createTodoListDTO.Owner, createTodoListDTO.Name);
}