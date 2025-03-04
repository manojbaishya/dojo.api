using System;
using System.Net.Http;
using Dojo.Api.Testing.Todo;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

namespace Dojo.Api.Testing;

public class IntegrationTestsFixture : IDisposable
{
    public IntegrationTestsFixture() => Factory = new DojoApiFactory<App>();
    public DojoApiFactory<App> Factory { get; private set; }

    public void Dispose()
    {
        Factory.Client.Dispose();
        Factory.Dispose();
        GC.SuppressFinalize(this);
    }
}

public class DojoApiFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
{
    public readonly HttpClient Client;
    public DojoApiFactory()
    {
        Client = CreateClient();
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            services.AddSingleton<ITodoService>(serviceProvider => { return new TodoService(Client); });
        });
    }
}