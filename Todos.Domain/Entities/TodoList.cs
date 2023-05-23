using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todos.Domain.Entities;

public class TodoList
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Owner { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public List<Todo> Items { get; set; } = new();

    public TodoList() { }

    public TodoList(string owner, string name)
    {
        Owner = owner;
        Name = name;
        CreatedAt = DateTime.Now;
        Items = new List<Todo>();
    }
}