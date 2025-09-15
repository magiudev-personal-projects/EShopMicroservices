
using Catalog.API.Features.CreateProduct;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});
var app = builder.Build();

app.UseCreateProductEndpoints();

app.Run();
