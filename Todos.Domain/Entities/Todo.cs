namespace Todos.Domain.Entities;

public class Todo
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? DueDate { get; set; }

    public Todo(string content, DateTime? dueDate)
    {
        Id = Guid.NewGuid();

        Content = content;
        DueDate = dueDate;

        Completed = false;
        CreatedAt = DateTime.UtcNow;
        CompletedAt = null;
    }
}