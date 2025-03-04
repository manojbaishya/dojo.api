using System.Net.Http;
using System.Threading.Tasks;

using Xunit;

using Dojo.Api.Todo;

using Microsoft.Extensions.DependencyInjection;

using Xunit.Abstractions;

namespace Dojo.Api.Testing.Todo;

public class TodoIntegrationTests(IntegrationTestsFixture fixture, ITestOutputHelper logger) : IClassFixture<IntegrationTestsFixture>
{
    private readonly ITodoService _todoService = fixture.Factory.Services.GetRequiredService<ITodoService>();

    [Fact]
    public async Task GetTodos()
    {
        // Arrange

        // Act
        logger.WriteLine("Fetching all Todos");
        HttpResponseMessage response = await _todoService.GetAll();

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task CreateTodo()
    {
        // Arrange
        TodoDto todo = new("Task 1", false);

        // Act
        logger.WriteLine("Creating a Todo: ");
        HttpResponseMessage response = await _todoService.Create(todo);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
