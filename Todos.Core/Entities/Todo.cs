namespace Todos.Core.Entities;

public class Todo
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public bool Completed { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public DateTime? DueDate { get; private set; }

    public Todo(string content, DateTime? dueDate)
    {
        Id = Guid.NewGuid();

        Content = content;
        DueDate = dueDate;

        Completed = false;
        CreatedAt = DateTime.UtcNow;
        CompletedAt = null;
    }

    public void ToogleCompleted()
    {
        CompletedAt = Completed ? null : DateTime.UtcNow;
        Completed = !Completed;
    }

    public void SetContent(string content) => Content = content;
    public void SetDueDate(DateTime? dueDate) => DueDate = dueDate;
}