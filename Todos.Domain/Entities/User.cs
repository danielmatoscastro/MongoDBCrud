namespace Todos.Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.Now;
    }
}