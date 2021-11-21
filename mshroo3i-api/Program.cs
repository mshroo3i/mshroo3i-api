using Microsoft.EntityFrameworkCore;
using Mshroo3i.Data;
using AutoMapper;
using mshroo3i_api;
using mshroo3i_api.Dtos;
using mshroo3i_api.Requests;

var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterServices(builder.Configuration);

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

    return Results.Ok(mapper.Map<StoreResponse>(store));
}).WithName("GetStore");

app.MapPut("api/stores/{shortcode}/product/{id}", async (int id, string shortcode, ProductRequest product, ApplicationContext context, IMapper mapper) =>
{
    var productToUpdate = await context.Products.FirstOrDefaultAsync(p => p.Store.Shortcode == shortcode && p.Id == id);
    if (productToUpdate is null)
    {
        return Results.NotFound();
    }
    
    mapper.Map(product, productToUpdate);
    await context.SaveChangesAsync();

    return Results.Ok();
}).WithName("UpdateProduct");

app.Run();