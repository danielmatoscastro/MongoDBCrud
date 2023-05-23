using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todos.Domain.Entities;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public User()
    {
        CreatedAt = DateTime.Now;
    }

    public User(string name)
    {
        Name = name;
        CreatedAt = DateTime.Now;
    }
}