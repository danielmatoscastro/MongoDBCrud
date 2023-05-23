namespace Todos.Application.Dtos;

public class CreateTodoListDTO
{
    public string Name { get; set; } = null!;
    public string Owner { get; set; } = null!;
}