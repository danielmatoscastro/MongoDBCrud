using Todos.Domain.Entities;

namespace Todos.Domain.Repositories;

public interface ITodoListRepository
{
    Task<TodoList> Create(TodoList todoList);
    Task<IEnumerable<TodoList>> GetAll();
    Task<TodoList> GetById(string id);
}