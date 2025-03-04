using Microsoft.EntityFrameworkCore;

namespace Dojo.Api;

public partial class ApplicationDbContext
{
    public DbSet<Todo.Todo> TodoItems { get; set; } = null!;
}
