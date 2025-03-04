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
    private readonly HttpClient _server = server;

    public async Task<HttpResponseMessage> GetAll() => await _server.GetAsync("/api/Todo");

    public async Task<HttpResponseMessage> GetById(int id) => await _server.GetAsync($"/api/Todo/{id}");

    public async Task<HttpResponseMessage> Create(TodoDto todoDto)
    {
        StringContent content = new(todoDto.ToString(), Encoding.UTF8, "application/json");
        return await _server.PostAsync("/api/Todo", content);
    }
}