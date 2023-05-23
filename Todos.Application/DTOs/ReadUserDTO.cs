namespace Todos.Application.Dtos;

public class ReadUserDTO
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}