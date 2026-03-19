using Ordering.Infrastructure;
using Ordering.Infrastructure.DbSeed;
using Application = Ordering.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
Application.AddServices(builder.Services);

builder.AddApiServices();

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    await app.InitialiseDatabaseAsync();
}

app.UseHttpsRedirection();

app.Run();
