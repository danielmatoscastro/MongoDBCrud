namespace Todos.Application.Dtos;

public class ReadTodoListDTO
{
    public string Id { get; set; } = null!;
    public string Owner { get; set; } = null!;
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<ReadTodoDTO> Items { get; set; } = new();
}