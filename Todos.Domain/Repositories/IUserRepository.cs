using Todos.Domain.Entities;

namespace Todos.Domain.Repositories;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> GetById(string id);
}