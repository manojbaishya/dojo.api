using Microsoft.AspNetCore.Mvc;

namespace Dojo.Api.TextGenerator;

[Route("api/[controller]")]
[ApiController]
public class TextController : ControllerBase
{
	private readonly Random _random = new();

    // NOTE GET: /api/Text
    [HttpGet]
    public async Task<IActionResult> GetText(int para, int maxWaitTime)
    {
        await Sleep(maxWaitTime);
        var text = new Text(para);
        return Ok(text);
    }

    private Task Sleep(int maxWaitTime) => Task.Delay((int)(_random.NextDouble() * maxWaitTime * 1000));
}