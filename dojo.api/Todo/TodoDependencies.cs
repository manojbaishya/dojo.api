using Microsoft.EntityFrameworkCore;

namespace Dojo.Api.Todo;

public class TodoDependencies : IDependencies
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {   
        builder.Services.AddScoped<ITodoService, TodoService>();
    }
}