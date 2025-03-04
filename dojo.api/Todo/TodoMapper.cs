using Riok.Mapperly.Abstractions;

namespace Dojo.Api.Todo;

[Mapper]
public partial class TodoMapper
{
    [MapperIgnoreSource(nameof(Todo.Id))]
    public partial TodoDto TodoToTodoDto(Todo todo);

    [MapperIgnoreTarget(nameof(Todo.Id))]
    public partial Todo TodoDtoToTodo(TodoDto todo);

    [MapperIgnoreTarget(nameof(Todo.Id))]
    public partial void Map(TodoDto todoDto, Todo todo);

}
