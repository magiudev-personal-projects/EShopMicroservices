
using BuildingBlocks.Behaviours;
using Catalog.API;
using Catalog.API.DbSeed;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);
var dbConnectionString = builder.Configuration.GetConnectionString("Database")!;
builder.Services.AddMarten(options =>
{
    options.Connection(dbConnectionString);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

builder.Services.AddExceptionHandler<ExceptionHandler>();

builder.Services.AddProblemDetails();

builder.Services.AddHealthChecks().AddNpgSql(dbConnectionString);

var app = builder.Build();

app.AddRoutes();

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.UseExceptionHandler();

app.Run();
