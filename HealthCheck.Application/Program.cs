using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks()
    .AddRedis(redisConnectionString: "localhost:6379", name: "redis")
    .AddMongoDb(mongodbConnectionString: "mongodb://localhost:27017", name: "mongodb", timeout: TimeSpan.FromSeconds(5));

builder.Services
    .AddHealthChecksUI(settings =>
    {
        settings.AddHealthCheckEndpoint("Main Health Checks", "/health");
    })
    .AddPostgreSqlStorage(connectionString: "User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=postgres;");

var app = builder.Build();

app.UseHttpsRedirection();

app.UseHealthChecks("/health", new HealthCheckOptions()
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseHealthChecksUI(opt => opt.UIPath = "/hc");

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
