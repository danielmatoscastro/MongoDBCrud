namespace Todos.Api.Dtos;

public class UpdateTodoDTO
{
    public string Content { get; set; } = null!;
    public DateTime? DueDate { get; set; }
}