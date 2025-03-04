using Microsoft.EntityFrameworkCore;

namespace Dojo.Api.Todo;

public class TodoDependencies : IDependencies
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("TodoList"));
        
        builder.Services.AddScoped<ITodoService, TodoService>();
    }
}