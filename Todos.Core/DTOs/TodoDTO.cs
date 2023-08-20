namespace Todos.Core.DTOs;

public class TodoDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? DueDate { get; set; }
}