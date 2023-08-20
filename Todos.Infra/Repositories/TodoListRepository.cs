using MongoDB.Bson;
using MongoDB.Driver;
using Todos.Core.Entities;
using Todos.Core.Repositories;

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

    public async Task Delete(TodoList todoList)
    {
        var todoLists = _mongoDBDataAccess.GetCollection<TodoList>(todoListCollection);
        await todoLists.DeleteOneAsync<TodoList>(t => t.Id == todoList.Id);
    }

    public Task<IEnumerable<TodoList>> GetAll()
    {
        var todoLists = _mongoDBDataAccess.GetCollection<TodoList>(todoListCollection);
        var data = todoLists.Find<TodoList>(_ => true).ToEnumerable();
        return Task.FromResult(data);
    }

    public Task<TodoList> GetById(Guid id)
    {
        var todoLists = _mongoDBDataAccess.GetCollection<TodoList>(todoListCollection);
        var filter = Builders<TodoList>.Filter.Eq(new StringFieldDefinition<TodoList, Guid>("_id"), id);
        return todoLists.Find<TodoList>(filter).FirstOrDefaultAsync();
    }

    public async Task Update(TodoList todoList)
    {
        var todoLists = _mongoDBDataAccess.GetCollection<TodoList>(todoListCollection);
        var filter = Builders<TodoList>.Filter.Eq("Id", todoList.Id);
        await todoLists.ReplaceOneAsync(filter, todoList);
    }
}