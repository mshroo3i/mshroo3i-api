using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using mshroo3i_api.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Mshroo3iDb");
var sqlConnection = ConnectionFactory.CreateSqlConnection(connectionString);
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(sqlConnection, sqlOptions => { sqlOptions.EnableRetryOnFailure(); });
    options.LogTo(Console.WriteLine);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(opt =>
{
    opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("api/stores/{shortcode}", async (string shortcode, ApplicationContext context, IMapper mapper) =>
{
    var store = await context.Stores
        .Include(s => s.Products)
        .ThenInclude(p => p.ProductOptions)
        .ThenInclude(po => po.Options)
        .FirstOrDefaultAsync(s => s.Shortcode == shortcode);
 
    if (store == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(mapper.Map<StoreDto>(store));
}).WithName("GetStore");

app.Run();