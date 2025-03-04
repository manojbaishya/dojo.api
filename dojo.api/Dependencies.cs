using Dojo.Api.Todo;

namespace Dojo.Api;

public interface IDependencies
{
    public void ConfigureServices(WebApplicationBuilder builder);
}


public class DomainDependencies
{
    /// <summary>
    /// NOTE: Inject Hard Domain Dependencies
    /// </summary>
    /// <returns> IList<IDependencies> </returns>
    public static IList<IDependencies> Create()
    {
        return [new TodoDependencies()];
    }
}