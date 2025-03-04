using Xunit;

namespace Dojo.Api.Testing.Todo;

public class TodoUnitTests
{
    [Fact]
    public void TestHello()
    {
        const string hello = "Hello";
        Assert.Equal(5, hello.Length);
    }
}
