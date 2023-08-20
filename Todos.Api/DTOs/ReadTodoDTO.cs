namespace Todos.Api.Dtos;

public class ReadTodoDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public DateTime? DueDate { get; set; }
    public bool Completed { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}