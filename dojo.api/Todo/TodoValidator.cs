namespace Dojo.Api.Todo;

public class TodoValidator
{
    public static bool Validate(TodoDto todoDto)
    {
        return todoDto.Name is not null;
    }
}
