using Todos.Core.Entities;

namespace Todos.Core.Repositories;

public interface ITodoListRepository
{
    Task<TodoList> Create(TodoList todoList);
    Task Delete(TodoList todoList);
    Task<IEnumerable<TodoList>> GetAll();
    Task<TodoList> GetById(Guid id);
    Task Update(TodoList todoList);
}