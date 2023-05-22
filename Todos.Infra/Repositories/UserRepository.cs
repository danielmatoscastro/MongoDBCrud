using Todos.Domain.Entities;
using Todos.Domain.Repositories;

namespace Todos.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private const string usersCollection = "users";

    private readonly MongoDBDataAccess _mongoDBDataAccess;

    public UserRepository(MongoDBDataAccess mongoDBDataAccess) => _mongoDBDataAccess = mongoDBDataAccess;

    public async Task<User> Create(User user)
    {
        var users = _mongoDBDataAccess.GetCollection<User>(usersCollection);
        await users.InsertOneAsync(user);
        return user;
    }
}