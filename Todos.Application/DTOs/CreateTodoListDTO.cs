namespace Todos.Application.Dtos;

public class CreateTodoListDTO
{
    public string Name { get; set; } = null!;
    public Guid Owner { get; set; }
}