using Microsoft.AspNetCore.Rewrite;
using mshroo3i_api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

// TODO: Do this at the DNS level using CloudFare
// See https://app.asana.com/0/1201502066479091/1201502862005579/f
var options = new RewriteOptions().AddRedirectToWwwPermanent();
app.UseRewriter(options);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();