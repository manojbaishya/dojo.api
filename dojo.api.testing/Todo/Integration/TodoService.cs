using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Dojo.Api.Todo;

namespace Dojo.Api.Testing.Todo;

public interface ITodoService
{
    Task<HttpResponseMessage> Create(TodoDto todoDto);
    Task<HttpResponseMessage> GetAll();
    Task<HttpResponseMessage> GetById(int id);
}

public class TodoService(HttpClient server) : ITodoService
{
    public async Task<HttpResponseMessage> GetAll() => await server.GetAsync("/api/Todo");

    public async Task<HttpResponseMessage> GetById(int id) => await server.GetAsync($"/api/Todo/{id}");

    public async Task<HttpResponseMessage> Create(TodoDto todoDto)
    {
        string payload = todoDto.ToString();
        StringContent content = new(payload, Encoding.UTF8, "application/json");
        return await server.PostAsync("/api/Todo", content);
    }
}