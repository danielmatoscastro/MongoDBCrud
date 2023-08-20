namespace Todos.Core.DTOs;

public class TodoListDTO
{
    public Guid Id { get; set; }
    public Guid Owner { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public IEnumerable<TodoDTO> Items { get; set; } = null!;
}