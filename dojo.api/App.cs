using Microsoft.EntityFrameworkCore;

namespace Dojo.Api;

public class App
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = CreateBuilderAndAddServices(args);
        WebApplication app = BuildAndConfigureApp(builder);
        app.Run();
    }

    private static WebApplicationBuilder CreateBuilderAndAddServices(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        IList<IDependencies> dependencies = DomainDependencies.Create();
        foreach (IDependencies dependency in dependencies)
        {
            dependency.ConfigureServices(builder);
        }

        string dojoApiDb = builder.Configuration.GetConnectionString("DojoApi") ?? throw new InvalidOperationException("Connection string 'DojoApi' not found.");

        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(dojoApiDb));

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        builder.Services.AddControllers();
        builder.Services.AddHealthChecks();
        builder.Services.AddOpenApi();

        return builder;
    }

    private static WebApplication BuildAndConfigureApp(WebApplicationBuilder builder)
    {
        WebApplication app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        CreateOrMigrateDatabase(app);

        app.UseAuthorization();
        app.MapControllers();
        app.MapHealthChecks("/health");

        return app;
    }
    
    private static void CreateOrMigrateDatabase(WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();
    }
}