namespace Todos.Application.Dtos;

public class ReadTodoDTO
{
    public string Id { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DateTime? DueDate { get; set; }
    public bool Completed { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime CreatedAt { get; set; }
}