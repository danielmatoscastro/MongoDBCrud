namespace Todos.Api.Dtos;

public class CreateTodoDTO
{
    public string Content { get; set; } = null!;
    public DateTime? DueDate { get; set; }
}