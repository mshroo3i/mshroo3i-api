using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Mshroo3iDb");
var sqlConnection = ConnectionFactory.CreateSqlConnection(connectionString);
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(sqlConnection, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
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
}).WithName("GetStore");

app.Run();