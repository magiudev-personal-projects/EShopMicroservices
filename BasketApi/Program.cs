using BasketApi;
using BasketApi.Data;
using BasketApi.Models;
using BuildingBlocks;
using BuildingBlocks.Behaviours;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using FluentValidation;
using Microsoft.Extensions.Caching.Distributed;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
var dbConnectionString = builder.Configuration.GetConnectionString("Database")!;
builder.Services.AddMarten(options =>
{
    options.Connection(dbConnectionString);
    options.Schema.For<Basket>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.Decorate<IRepository, CachedRepository>();

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(dbConnectionString);

builder.Services.AddProblemDetails();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

var app = builder.Build();

app.UseExceptionHandler();
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.AddRoutes();

app.Run();
