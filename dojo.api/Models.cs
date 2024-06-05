using System;
using System.Linq;

using RimuTec.Faker;

namespace dojo.api;

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public static readonly string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);
}

public readonly struct Essay(int NumberOfParagraphs)
{
    public readonly ReadOnlyMemory<string> Paragraphs { get; } = Lorem.Paragraphs(NumberOfParagraphs).ToArray();
}