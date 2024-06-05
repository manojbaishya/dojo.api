using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dojo.api;

public static class Program
{
    private static void Main(string[] args)
    {
        var api = new Api(args);
        api.Execute();
    }
}

public class Api
{
    public Api(string[] args)
    {
        webAppBuilder = ConfigureServices(args);
        app = ConfigureMiddleware();
        ConfigureEndpoints();
    }

    public void Execute() => app.Run();

    private static WebApplicationBuilder ConfigureServices(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddHttpLogging(logging => logging.LoggingFields = HttpLoggingFields.Request);

        return builder;
    }

    private WebApplication ConfigureMiddleware()
    {
        WebApplication appInstance = webAppBuilder.Build();
        if (appInstance.Environment.IsDevelopment())
        {
            appInstance.UseSwagger();
            appInstance.UseSwaggerUI();
        }
        appInstance.UseHttpLogging();

        // appInstance.UseHttpsRedirection();

        return appInstance;
    }

    private void ConfigureEndpoints()
    {
        GetAllWeatherForecasts();
        GetEssay();
    }

    private void GetAllWeatherForecasts()
    => app.MapGet("/weatherforecast", () =>
            Enumerable.Range(1, 5)
            .Select(index =>
                new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    WeatherForecast.summaries[Random.Shared.Next(WeatherForecast.summaries.Length)]
                )).ToArray()
        )
        .WithName("GetWeatherForecast")
        .WithOpenApi();

    private void GetEssay()
    => app.MapGet("/essay", async (int para, int maxWaitTime) =>
    {
        await Sleep(maxWaitTime);
        return new Essay(para);
    });

    private Task Sleep(int maxWaitTime) => Task.Delay((int) (random.NextDouble() * maxWaitTime * 1000));

    #region Fields
    private readonly WebApplicationBuilder webAppBuilder;
    private readonly WebApplication app;
    private readonly Random random = new();

    #endregion

}
