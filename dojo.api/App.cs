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

        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        
        builder.Services.AddControllers();
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

        app.UseAuthorization();
        app.MapControllers();
        
        return app;
    }
}