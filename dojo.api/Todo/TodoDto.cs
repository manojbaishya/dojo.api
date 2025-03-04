namespace Dojo.Api.Todo;

public record TodoDto(string? Name, bool IsComplete)
{
    public override string ToString() => $$"""{"name":"{{Name}}", "isComplete": {{IsComplete.ToString().ToLower()}}}""";
}