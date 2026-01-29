using BasketApi;
using BasketApi.Data;
using BasketApi.Models;
using BuildingBlocks;
using BuildingBlocks.Behaviours;
using FluentValidation;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

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

builder
    .Services.AddMarten(options =>
    {
        options.Connection(dbConnectionString);
        options.Schema.For<Basket>().Identity(x => x.UserName);
    })
    .UseLightweightSessions();

builder.Services.AddScoped<IRepository, Repository>();

builder.Services.Decorate<IRepository, CachedRepository>();

builder.Services.AddExceptionHandler<ExceptionHandler>();

var redisConnectionstring = builder.Configuration.GetConnectionString("Redis")!;
builder.Services.AddHealthChecks().AddNpgSql(dbConnectionString).AddRedis(redisConnectionstring);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = redisConnectionstring;
});

builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

app.UseHealthChecks(
    "/health",
    new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse }
);

app.AddRoutes();

app.Run();
