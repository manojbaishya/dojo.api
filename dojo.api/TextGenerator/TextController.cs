using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Dojo.Api.TextGenerator;

[Route("api/[controller]")]
[ApiController]
public class TextController : ControllerBase
{
	private readonly Random _random;
    public TextController()
    {
        _random = new Random();
    }
	
	// NOTE GET: /api/Text
    [HttpGet]
    public async Task<IActionResult> GetText(int para, int maxWaitTime)
    {
        await Sleep(maxWaitTime);
        var Text = new Text(para);
        return Ok(Text);
    }

    private Task Sleep(int maxWaitTime) => Task.Delay((int)(_random.NextDouble() * maxWaitTime * 1000));
}