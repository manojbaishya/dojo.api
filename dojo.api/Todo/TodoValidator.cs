namespace Dojo.Api.Todo;

public class TodoValidator
{
    public static bool Validate(TodoDto todoDto)
    {
        if (todoDto.Name is null) return false;
        return true;
    }

}
