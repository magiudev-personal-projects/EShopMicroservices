using Ordering.Infrastructure;
using Ordering.Infrastructure.DbSeed;
using Application = Ordering.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
Application.AddServices(builder);

builder.AddServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
