using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.DbSeed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddApplicationServices().AddApiServices();

var app = builder.Build();

app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    await app.InitialiseDatabaseAsync();
}

app.UseHttpsRedirection();

app.Run();
