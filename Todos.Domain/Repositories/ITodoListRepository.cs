using Todos.Domain.Entities;

namespace Todos.Domain.Repositories;

public interface ITodoListRepository
{
    Task<TodoList> Create(TodoList todoList);
    Task<TodoList> GetById(string id);
}