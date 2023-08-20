using Todos.Core.DTOs;
using Todos.Core.Entities;
using Todos.Core.Exceptions;
using Todos.Core.Mappings;
using Todos.Core.Repositories;

namespace Todos.Core.Services;

public class TodoListService
{
    private readonly ITodoListRepository _todoListRepository;

    public TodoListService(ITodoListRepository todoListRepository)
    {
        _todoListRepository = todoListRepository;
    }

    public async Task<IEnumerable<TodoListDTO>> GetAll()
    {
        var todoLists = await _todoListRepository.GetAll();
        return todoLists.ToTodoListDTO();
    }

    public async Task<TodoListDTO> GetById(Guid id)
    {
        var todoListEntity = await GetTodoList(id);
        return todoListEntity.ToTodoListDTO();
    }

    public async Task<TodoListDTO> Create(TodoListDTO todoListDTO)
    {
        var todoListEntity = todoListDTO.ToTodoListEntity();
        await _todoListRepository.Create(todoListEntity);
        return todoListEntity.ToTodoListDTO();
    }

    public async Task Delete(Guid id)
    {
        var todoListEntity = await GetTodoList(id);
        await _todoListRepository.Delete(todoListEntity);
    }

    public async Task<TodoListDTO> Update(Guid id, TodoListDTO todoListDTO)
    {
        var todoListEntity = await GetTodoList(id);

        todoListEntity.SetName(todoListDTO.Name);

        await _todoListRepository.Update(todoListEntity);

        return todoListEntity.ToTodoListDTO();
    }

    public async Task<TodoDTO> CreateTodo(Guid todoListId, TodoDTO todoDTO)
    {
        var todoListEntity = await GetTodoList(todoListId);

        var todoEntity = todoDTO.ToTodoEntity();

        todoListEntity.AddItem(todoEntity);

        await _todoListRepository.Update(todoListEntity);

        return todoEntity.ToTodoDTO();
    }

    public async Task<TodoDTO> GetTodo(Guid todoListId, Guid todoId)
    {
        var todoListEntity = await GetTodoList(todoListId);
        var todoEntity = GetTodo(todoListEntity, todoId);
        return todoEntity.ToTodoDTO();
    }

    public async Task<TodoDTO> ToogleCompletedTodo(Guid todoListId, Guid todoId)
    {
        var todoListEntity = await GetTodoList(todoListId);
        var todoEntity = GetTodo(todoListEntity, todoId);

        todoEntity.ToogleCompleted();

        await _todoListRepository.Update(todoListEntity);

        return todoEntity.ToTodoDTO();
    }

    public async Task<TodoDTO> UpdateTodo(Guid todoListId, Guid todoId, TodoDTO todoDTO)
    {
        var todoListEntity = await GetTodoList(todoListId);
        var todoEntity = GetTodo(todoListEntity, todoId);

        todoEntity.SetContent(todoDTO.Content);
        todoEntity.SetDueDate(todoDTO.DueDate);

        await _todoListRepository.Update(todoListEntity);

        return todoEntity.ToTodoDTO();
    }

    public async Task DeleteTodo(Guid todoListId, Guid todoId)
    {
        var todoListEntity = await GetTodoList(todoListId);

        var amountRemoved = todoListEntity.RemoveItem(todoId);
        if (amountRemoved == 0)
        {
            throw new EntityNotFoundException(typeof(Todo), todoId);
        }

        await _todoListRepository.Update(todoListEntity);
    }

    private async Task<TodoList> GetTodoList(Guid id)
    {
        var todoListEntity = await _todoListRepository.GetById(id);
        if (todoListEntity == null)
        {
            throw new EntityNotFoundException(typeof(TodoList), id);
        }
        return todoListEntity;
    }

    private Todo GetTodo(TodoList todoListEntity, Guid todoId)
    {
        var todoEntity = todoListEntity.Items.FirstOrDefault(item => item.Id == todoId);
        if (todoEntity == null)
        {
            throw new EntityNotFoundException(typeof(Todo), todoId);
        }
        return todoEntity;
    }
}