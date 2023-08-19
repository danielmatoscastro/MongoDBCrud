namespace Todos.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public User(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.Now;
    }
}