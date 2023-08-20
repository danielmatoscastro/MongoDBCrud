namespace Todos.Core.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(Type type, Guid id) : base($"Entity {type.FullName} with Id = {id} not found.")
    {
    }
}