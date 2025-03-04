using Microsoft.AspNetCore.Mvc;

namespace Dojo.Api.Todo;

[Route("api/[controller]")]
[ApiController]
public class TodoController(ITodoService todoService) : ControllerBase
{
    // NOTE GET: /api/Todo
    [HttpGet] public async Task<ActionResult<IEnumerable<Todo>>> GetTodoItems() => Ok(await todoService.GetTodoItems());

    // NOTE GET: /api/Todo/5
    [HttpGet("{id}")] public async Task<ActionResult<Todo>> GetTodoItem(long id) => await todoService.GetTodoItemById(id) is { } todoItem ? Ok(todoItem) : NotFound();

    // NOTE PUT: /api/Todo/5
    [HttpPut("{id}")] public async Task<IActionResult> PutTodoItem(long id, [FromBody] TodoDto todoDto) => await todoService.UpdateTodoItem(id, todoDto) ? NoContent() : NotFound();

    // NOTE POST: /api/Todo
    [HttpPost] public async Task<ActionResult<Todo>> PostTodoItem([FromBody] TodoDto todoDto) => CreatedAtAction(nameof(GetTodoItem), new { id = await todoService.CreateTodoItem(todoDto) }, todoDto);

    // NOTE DELETE: /api/Todo/5
    [HttpDelete("{id}")] public async Task<IActionResult> DeleteTodoItem(long id) => await todoService.DeleteTodoItem(id) ? NoContent() : NotFound();
}
