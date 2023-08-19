namespace Todos.Domain.Entities;

public class TodoList
{
    public Guid Id { get; set; }

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