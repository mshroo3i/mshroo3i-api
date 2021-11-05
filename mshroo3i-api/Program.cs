using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseNpgsql(ApplicationContext.ConnectionString);
    options.LogTo(Console.WriteLine);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(opt =>
{
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("{apiVersion}/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateTime.Now.AddDays(index),
           Random.Shared.Next(-20, 55),
           ""
       ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("api/stores/{shortcode}", async (string shortcode, string? myquery, ApplicationContext context) =>
{
    Console.WriteLine(myquery);

    var store = await context.Stores
        .Include(s => s.Products)
        .ThenInclude(p => p.ProductOptions)
        .ThenInclude(po => po.Options)
        .FirstOrDefaultAsync(s => s.Shortcode == shortcode);
 
    if (store == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(store);
});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}