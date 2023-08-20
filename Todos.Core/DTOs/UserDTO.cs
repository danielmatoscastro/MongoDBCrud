namespace Todos.Core.DTOs;

public class UserDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}