using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todos.Domain.Entities;

public class Todo
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Content { get; set; } = null!;
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? DueDate { get; set; }

    public Todo(string content) : this(content, null)
    {

    }

    public Todo(string content, DateTime? dueDate)
    {
        Content = content;
        DueDate = dueDate;

        Completed = false;
        CreatedAt = DateTime.UtcNow;
        CompletedAt = null;
    }
}