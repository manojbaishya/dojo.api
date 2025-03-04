namespace Dojo.Api.Todo;

public interface ITodoService
{
    public Task<IList<Todo>> GetTodoItems();
    public Task<Todo?> GetTodoItemById(long id);
    
    public Task<Todo> CreateTodoItem(TodoDto todoDto);

    public Task<bool> UpdateTodoItem(long id, TodoDto todoDto);

    public Task<bool> DeleteTodoItem(long id);
}

public class TodoService(IRepository<Todo> todoRepository) : ITodoService
{
    private readonly IRepository<Todo> _todoRepository = todoRepository;

    public async Task<Todo> CreateTodoItem(TodoDto todoDto)
    {
        TodoMapper todoMapper = new();
        Todo todoItem = todoMapper.TodoDtoToTodo(todoDto);
        return await _todoRepository.Add(todoItem);
    }

    public async Task<bool> DeleteTodoItem(long id) => await _todoRepository.Delete(id);

    public async Task<Todo?> GetTodoItemById(long id) => await _todoRepository.GetById(id);

    public async Task<IList<Todo>> GetTodoItems() => await _todoRepository.GetAll();

    public async Task<bool> UpdateTodoItem(long id, TodoDto todoDto)
    {
        Todo? todoItem = await GetTodoItemById(id);
        if (todoItem is null) return false;
        TodoMapper todoMapper = new();
        todoMapper.Map(todoDto, todoItem);
        return await _todoRepository.Update(todoItem);
    }
}
