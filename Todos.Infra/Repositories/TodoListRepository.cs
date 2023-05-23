using MongoDB.Driver;
using Todos.Domain.Entities;
using Todos.Domain.Repositories;

namespace Todos.Infra.Repositories;

public class TodoListRepository : ITodoListRepository
{
    private const string todoListCollection = "todoLists";

    private readonly MongoDBDataAccess _mongoDBDataAccess;

    public TodoListRepository(MongoDBDataAccess mongoDBDataAccess)
    {
        _mongoDBDataAccess = mongoDBDataAccess;
    }

    public async Task<TodoList> Create(TodoList todoList)
    {
        var todoLists = _mongoDBDataAccess.GetCollection<TodoList>(todoListCollection);
        await todoLists.InsertOneAsync(todoList);
        return todoList;
    }

    public Task<TodoList> GetById(string id)
    {
        var todoLists = _mongoDBDataAccess.GetCollection<TodoList>(todoListCollection);
        var filter = Builders<TodoList>.Filter.Eq("Id", id);
        return todoLists.Find<TodoList>(filter).FirstOrDefaultAsync();
    }
}