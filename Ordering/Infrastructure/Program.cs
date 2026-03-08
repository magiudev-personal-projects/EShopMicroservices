using Application = Ordering.Application.DependencyInjection;
using Infrastructure = Ordering.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

Application.AddServices(builder.Services);
Infrastructure.AddServices(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
