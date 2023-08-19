namespace Todos.Domain.Entities;

public class TodoList
{
    private List<Todo> _items;

    public Guid Id { get; private set; }

    public Guid Owner { get; private set; }

    public string Name { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public IReadOnlyCollection<Todo> Items { get => _items.AsReadOnly(); }

    public TodoList(Guid owner, string name)
    {
        Id = Guid.NewGuid();
        Owner = owner;
        Name = name;
        CreatedAt = DateTime.Now;
        _items = new List<Todo>();
    }

    public void SetName(string name) => Name = name;
    public void AddItem(Todo todo) => _items.Add(todo);
    public int RemoveItem(Guid todoId) => _items.RemoveAll(item => item.Id == todoId);
}