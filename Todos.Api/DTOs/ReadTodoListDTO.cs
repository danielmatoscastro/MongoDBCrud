namespace Todos.Api.Dtos;

public class ReadTodoListDTO
{
    public Guid Id { get; set; }
    public Guid Owner { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public List<ReadTodoDTO> Items { get; set; } = new();
}