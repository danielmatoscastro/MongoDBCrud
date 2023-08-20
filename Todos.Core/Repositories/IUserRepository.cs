using Todos.Core.Entities;

namespace Todos.Core.Repositories;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<User> GetById(Guid id);
}