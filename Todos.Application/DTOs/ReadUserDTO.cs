namespace Todos.Application.Dtos;

public class ReadUserDTO
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}