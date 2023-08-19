using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todos.Domain.Entities;

public class TodoList
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Owner { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public List<Todo> Items { get; set; } = new();

    public TodoList(Guid owner, string name)
    {
        Id = Guid.NewGuid();
        Owner = owner;
        Name = name;
        CreatedAt = DateTime.Now;
        Items = new List<Todo>();
    }
}